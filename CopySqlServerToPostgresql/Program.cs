
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CopySqlServerToPostgresql
{
    /// <summary>
    /// Copy Sql Server catalog to PostgreSQL ("AdventureWorksLT2008R2" in debug mode).
    /// Both Sql Server and PostgreSQL need to be running.
    /// Npgsql will be installed by NuGet package manager.
    /// http://www.codeproject.com/Tips/1068276/Convert-SQL-Server-database-to-PostgreSQL
    /// </summary>
    class Program
    {
        // Array for indexes and primary keys.
        public static string[] indexes;

        // Array for DEFAULT values.
        public static string[] defaults;

        /// <summary>
        /// SQL Server Express used on first try.
        /// </summary>
        public static string Server = @"(local)";

        /// <summary>
        /// PostgreSQL Server.
        /// </summary>
        public static string Server2 = @"127.0.0.1";

        /// <summary>
        /// SQL Server db name.
        /// </summary>
        public static string Catalog = "DamaServer";

        /// <summary>
        /// PostgreSQL db name (in lower case).
        /// </summary>
        public static string Catalog2;

        /// <summary>
        /// SQL Server user name (empty for Windows Authentication).
        /// </summary>
        public static string Username = "sa";

        /// <summary>
        /// PostgreSQL user name.
        /// </summary>
        public static string Username2 = "postgres";

        public static string Password = "P@55w0rd";

        public static string Password2 = "P@55w0rd";

        public static string ProviderName = @"System.Data.SqlClient";

        public static string ProviderName2 = @"Npgsql";

        /// <summary>
        /// The SQL Server database port.
        /// </summary>
        public static int DatabasePort = 1433;

        /// <summary>
        /// The PostgreSQL database port.
        /// </summary>
        public static int DatabasePort2 = 5432;

        /// <summary>
        /// Gets or sets the last errror.
        /// </summary>
        public static string LastErrror { get; set; }

        /// <summary>
        /// Get command line arguments (in Release mode)
        /// Use "AdventureWorksLT2008R2" (in Debug mode)
        /// Start conversion to PostgreSQL.
        /// </summary>
        /// <param name="args">Expects at least one catalog name, and optional PostgreSQL catalog name as second argument.</param>
        static int Main(string[] args)
        {
            Console.WriteLine("Welcome. This application copies both the schema and data of an existing" +
                "SQL Server database to a postgre database. If the postgre database already exists," +
                "it is dropped and recreted");

            Console.Write("Please provide database name [default: DamaServer]: ");
            var data = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(data))
            {
                Catalog = data;
            }
            Stopwatch stopWatch1 = new Stopwatch();

#if DEBUG
            Catalog2 = Catalog;//;
#else
            if (args.Length == 0 || args.Length > 2)
            {
                Console.WriteLine(@"Usage: CopySqlServerToPostgresql sqlServerCatalogname [postgresqlCatalogname]");
                Console.WriteLine();
                Console.ReadKey();
                return 1;
            }
            else
            {
                Catalog = args[0];

                if (args.Length == 1)
                {
                    // Only one argument, copy the catalog name for PostgreSQL.
                    Catalog2 = Catalog;
                }
                else
                {
                    Catalog2 = args[1];
                }
            }
#endif
            var connectionStringSqlServer = GetConnectionString(Server, Catalog, Username, Password);
            var connectionStringPostgresql = GetConnectionString(Server2, Catalog2, Username2, Password2, ProviderName2, DatabasePort2);

            // Check SQL Server connection.
            if (CheckSqlServer(ref connectionStringSqlServer))
            {
                Console.WriteLine(connectionStringSqlServer);
                Console.WriteLine();
                Console.WriteLine(connectionStringPostgresql);
                Console.WriteLine();
                Console.WriteLine("-----------------------------");

                stopWatch1.Start();

                // Try to open PostgreSQL connection first, create if it does not exist.
                string result = OpenPostgreSql(connectionStringPostgresql);

                if (string.IsNullOrEmpty(result))
                {
                    // Copy to PostgreSQL database.
                    Console.WriteLine("-----------------------------");
                    result = CopyToPostgreSql(connectionStringSqlServer, connectionStringPostgresql);
                    Console.WriteLine("-----------------------------");
                    CreateViews(connectionStringSqlServer, connectionStringPostgresql);
                    Console.WriteLine("-----------------------------");
                    CreateForeignKeys(connectionStringSqlServer, connectionStringPostgresql);
                    Console.WriteLine("-----------------------------");
                }
                stopWatch1.Stop();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(result + string.Format(" in {0} seconds", stopWatch1.ElapsedMilliseconds / 1000));
            }

            Console.ReadKey();
            return 0;
        }

        /// <summary>
        /// Try to connect to SQLEXPRESS, if this fails try standard SQL Server.
        /// https://blogs.msdn.microsoft.com/sql_protocols/2008/09/19/understanding-data-sourcelocal-in-sql-server-connection-strings/
        /// </summary>
        /// <returns>True on success.</returns>
        public static bool CheckSqlServer(ref string connectionStringSqlServer)
        {
            bool result;

            using (var msConnection = new SqlConnection(connectionStringSqlServer))
            {
                msConnection.Open();
                result = msConnection.State == System.Data.ConnectionState.Open;

                if (result)
                {
                    Console.WriteLine("SQL Server Express " + msConnection.ServerVersion);
                }
                else
                {
                    // Not SQLEXPRESS, try standard SQL Server.
                    Server = @"(local)";
                    connectionStringSqlServer = GetConnectionString(Server, Catalog, Username, Password);

                    using (var msConnection2 = new SqlConnection(connectionStringSqlServer))
                    {
                        msConnection2.Open();
                        result = msConnection2.State == System.Data.ConnectionState.Open;

                        if (result)
                        {
                            Console.WriteLine("SQL Server " + msConnection.ServerVersion);
                        }
                        else
                        {
                            Console.WriteLine("Could not connect to SQL Server.");
                        }
                    }
                }
            }

            Console.WriteLine();
            return result;
        }

        /// <summary>
        /// Determine if PostgreSQL is used.
        /// </summary>
        /// <param name="connectionstring">The connectionstring.</param>
        /// <returns>True or false.</returns>
        public static bool IsPostgresql(string connectionstring)
        {
            return connectionstring.ToLower().Contains("server=");
        }

        /// <summary>
        /// Try to open PostgreSQL connection, if it fails create a new database.
        /// </summary>
        /// <param name="connectionStringPostgresql">The Postgresql connectionString.</param>
        /// <returns>Empty string on success.</returns>
        public static string OpenPostgreSql(string connectionStringPostgresql)
        {
            bool catalogExists = false;

            using (var pgConnection1 = new NpgsqlConnection(connectionStringPostgresql))
            {
                try
                {
                    pgConnection1.Open();
                    catalogExists = pgConnection1.State == ConnectionState.Open;
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);

                    if (!ex.Message.Contains("does not exist"))
                    {
                        // Other error than "database does not exist"
                        return ex.Message;
                    }
                }
            }

            if (catalogExists)
            {
                // TODO: "Are you sure you want to overwrite: " + Catalog2
                //return "Cancelled.";
                Console.WriteLine(@"DROP DATABASE " + Catalog2);

                try
                {
                    // DROP DATABASE.
                    // Connection to main database "postgres", typically with: username "postgres", password "postgres".
                    var connWithoutCatalog2 = GetConnectionString(Server2, string.Empty, Username2, Password2, ProviderName2, DatabasePort2);
                    DeleteDatabase(connWithoutCatalog2, Catalog2);
                }
                catch (Exception ex)
                {
                    var message = $"Could not drop database {Catalog2}. Here is a message from the db server: {Environment.NewLine}{ex.Message}";
                    return message;
                }
            }

            // Create new database.
            string pgSql = string.Format("CREATE DATABASE \"{0}\";", Catalog2);
            Debug.Print(pgSql);

            // Connection to main database "postgres", typically with: username "postgres", password "postgres".
            var connWithoutCatalog = GetConnectionString(Server2, string.Empty, Username2, Password2, ProviderName2, DatabasePort2);
            var resultCreate = ExecuteSqlScript(connWithoutCatalog, pgSql);

            using (var pgConnection = new NpgsqlConnection(connectionStringPostgresql))
            {
                if (resultCreate)
                {
                    pgConnection.Open();
                }

                if (pgConnection.State != ConnectionState.Open)
                {
                    return @"Error could not open connection: " + connectionStringPostgresql;
                }
            }

            //-- Needed for: uuid PRIMARY KEY DEFAULT uuid_generate_v1()
            ExecuteSqlScript(connectionStringPostgresql, "CREATE EXTENSION \"uuid-ossp\";");

            return string.Empty;
        }

        /// <summary>
        /// Copy data from MSSQL directly to PostgreSQL.
        /// If the target database does not exist, create it.
        /// </summary>
        public static string CopyToPostgreSql(string connectionStringSqlServer, string connectionStringPostgresql)
        {
            var msTables = new List<string>();
            var msColumns = new List<string>();
            var msColumnsB = new List<string>();
            var pgColumns = new List<string>();
            int pgTableCount = 0;

            using (var pgConnection = new NpgsqlConnection(connectionStringPostgresql))
            {
                pgConnection.Open();

                // Process all SQL Server tables.
                using (var msConnection = new SqlConnection(connectionStringSqlServer))
                {
                    msConnection.Open();

                    if (msConnection.State == ConnectionState.Open)
                    {
                        // Get only tables, not views.
                        // https://msdn.microsoft.com/en-us/library/ms254969(v=vs.110).aspx
                        DataTable dt = msConnection.GetSchema("Tables", new string[] { null, null, null, "BASE TABLE" });

                        foreach (DataRow rowTable in dt.Rows)
                        {
                            string msSchema = (string)rowTable[1];
                            string msTablename = (string)rowTable[2];
                            string pgTablename = msTablename.Replace(' ', '_');

                            if (pgTablename == "sysdiagrams")
                            {
                                continue;
                            }

                            //Console.WriteLine("-----------------------------");
                            Console.WriteLine(msTablename);
                            msTables.Add(msTablename);
                            msColumns.Clear();
                            msColumnsB.Clear();
                            pgColumns.Clear();

                            ////Database.ExecuteSqlScript(this.ConnectionStringPostgresql, "ALTER TABLE " + pgTablename + " DISABLE TRIGGER ALL;");
                            ////Database.ExecuteSqlScript(this.ConnectionStringPostgresql, "DELETE FROM " + pgTablename + ";");

                            // Get the columns, convert data types to PostgreSQL, also fill this.indexes array.
                            var pgCreateFields = GetFieldInformation(msConnection, msTablename, ref msColumns, ref msSchema);

                            // Add schema to tablename.
                            var pgSchema = msSchema.Replace(' ', '_');
                            pgTablename = $"{pgSchema}.\"{pgTablename}\"";
                            bool result1 = ExecuteSqlScript(connectionStringPostgresql, "create schema if not exists " + pgSchema + ";");

                            // Create PostgreSQL table with column names and field definitions, example:
                            // CREATE TABLE test (
                            //    id            uuid NOT NULL,
                            //    number        int NULL,
                            //    constraint    pk_name primary key(id,number) )
                            var pgSql1 = string.Format("create table {0} ({1});", pgTablename, pgCreateFields);
                            Debug.Print(pgSql1);
                            bool result2 = ExecuteSqlScript(connectionStringPostgresql, pgSql1);

                            // Create DEFAULT values.
                            if (defaults != null)
                            {
                                foreach (string pgDefault in defaults)
                                {
                                    Debug.Print(pgDefault);
                                    ExecuteSqlScript(connectionStringPostgresql, pgDefault);
                                }
                            }

                            // Indexes can only be created after "create table".
                            if (indexes != null)
                            {
                                foreach (string pgIndex in indexes)
                                {
                                    if (!pgIndex.StartsWith("constraint"))
                                    {
                                        // "create index".
                                        Debug.Print(pgIndex);
                                        ExecuteSqlScript(connectionStringPostgresql, pgIndex);
                                    }
                                }
                            }

                            // Replace spaces with underscores for PostgreSQL.
                            // Surround fields with brackets for SQL Server.
                            for (int i = 0; i < msColumns.Count; i++)
                            {
                                //pgColumns.Add("\"" + msColumns[i] + "\"");
                                pgColumns.Add(msColumns[i].Replace(' ', '_'));
                                msColumnsB.Add("[" + msColumns[i] + "]");
                            }

                            var cols = pgColumns.Select(c => $"\"{c}\"").ToList();
                            string msColumnsJoin = string.Join(",", msColumnsB);
                            string pgColumnsJoin = string.Join(",", cols);
                            string pgParameters = "@" + string.Join(",@", pgColumns);

                            // Read values from source db.
                            var command = msConnection.CreateCommand();
                            var msSql = string.Format(@"SELECT {0} FROM [{1}].[{2}].[{3}]", msColumnsJoin, Catalog, msSchema, msTablename);
                            Debug.Print(msSql);
                            command.CommandText = msSql;

                            // Insert values into target db.
                            using (var dr = command.ExecuteReader(CommandBehavior.Default))
                            {
                                uint pgInsertedCount = 0;
                                uint pgFailedCount = 0;

                                // Create insert query with column names and @ parameterlist.
                                var pgSql = string.Format("INSERT INTO {0} ({1}) VALUES ({2});", pgTablename, pgColumnsJoin, pgParameters);
                                //Debug.Print(pgSql);
                                object[] rowObjects = new object[msColumns.Count];

                                //List<Task> tasks = new List<Task>();

                                //while (dr.Read())
                                //{
                                //    int result = dr.GetValues(rowObjects);

                                //    Task t = Task.Run(() => { CopyToPostgreSql2(connectionStringPostgresql, pgSql, pgColumns, rowObjects); });
                                //    tasks.Add(t);

                                //    if (tasks.Count > 5)
                                //    {
                                //        Task.WaitAll(tasks.ToArray());
                                //    }
                                while (dr.Read())
                                {
                                    int result = dr.GetValues(rowObjects);
                                    result = ExecuteParameterQuery(pgConnection, pgSql, pgColumns, rowObjects);

                                    if (result < 1)
                                    {
                                        pgFailedCount++;
                                        Debug.Print(@"Error: " + pgSql);
                                    }
                                    else
                                    {
                                        pgInsertedCount++;
                                        Console.Write($"\rInserted {pgInsertedCount} records ({pgFailedCount} failed)");
                                    }
                                }

                                if(pgInsertedCount == 0 && pgFailedCount == 0)
                                {
                                    Console.WriteLine($"Inserted {pgInsertedCount} records ({pgFailedCount} failed)");
                                }

                                Console.WriteLine(string.Empty);
                                Console.WriteLine(string.Empty);
                                //Task.WaitAll(tasks.ToArray());
                            }

                            pgTableCount++;
                            //// ExecuteSqlScript(this.ConnectionStringPostgresql, "ALTER TABLE " + pgTablename + " ENABLE TRIGGER ALL;");
                            Debug.Print(string.Empty);
                        }
                    }
                }
            }

            return string.Format("Copied {0} tables of {1}", pgTableCount, msTables.Count);
        }

        /// <summary>
        /// Get the indexes (including primary key) formatted PostgreSQL style: 
        /// "constraint pk_name primary key(field1,field2,field3 ...)".
        /// "create index index_name on tableName (field1,field2,field3 ...)"
        /// </summary>
        public static string[] GetIndexes(SqlConnection msConnection, string tableName, string schema)
        {
            string indexName = string.Empty;
            string indexColumns = string.Empty;
            string pgTableName = $"{schema}.\"{tableName}\"";
            var indexes = new List<string>();

            try
            {
                var command = msConnection.CreateCommand();

                // Find indexes, including the primary key.
                // EXEC sys.sp_helpindex @objname = N'dbo.tablename'
                // EXEC sys.sp_helpconstraint @objname = N'dbo.tablename', @nomsg = N'nomsg'
                var msSql = string.Format("EXEC sys.sp_helpindex @objname = N'{0}.{1}' ", schema, tableName);
                command.CommandText = msSql;

                using (var dr = command.ExecuteReader(CommandBehavior.Default))
                {
                    while (dr.Read())
                    {
                        // 0 = index_name, 1 = index_description, 2 = index_keys.
                        object[] rowObjects = new object[3];
                        int result = dr.GetValues(rowObjects);
                        indexName = rowObjects[0].ToString();
                        var description = rowObjects[1].ToString();
                        indexColumns = rowObjects[2].ToString();
                        ////Debug.Print(indexName + " / " + description + " / " + indexColumns);
                        indexName = indexName.Replace(' ', '_');
                        indexColumns = indexColumns.Replace(", ", ",");
                        indexColumns = indexColumns.Replace(' ', '_');

                        // TODO: descending indexed column with (-) at end ?
                        indexColumns = indexColumns.Replace("(-)", string.Empty);
                        indexColumns = $"\"{indexColumns.Replace(",", "\", \"")}\"";

                        if (description.Contains("primary key"))
                        {
                            string pk = string.Format("constraint \"{0}\" primary key({1})", indexName, indexColumns);
                            indexes.Add(pk);
                        }
                        else
                        {
                            string ix = string.Format("create index \"{0}\" on {1} ({2});", indexName, pgTableName, indexColumns);
                            indexes.Add(ix);
                        }
                    }
                }
            }
            catch
            {
                Debug.Print("GetIndexes() error.");
            }

            if (string.IsNullOrEmpty(indexName))
            {
                // No PK or indexes found for this table.
                return null;
            }

            return indexes.ToArray();
        }

        /// <summary>
        /// Get the DEFAULTS formatted PostgreSQL style, example: 
        /// "alter table tablename alter column columnname set default 'false';"
        /// "alter table tablename alter column columnname set default (0);"
        /// Note: ROWGUIDCOL will not be found here.
        /// </summary>
        public static List<string> GetDefaults(SqlConnection msConnection, string tableName, List<string> fields, string schema)
        {
            string constraintName = string.Empty;
            string constraintKeys = string.Empty;
            string pgTableName = schema + "." + tableName;
            pgTableName = pgTableName;
            var defaultsTemp = new List<string>();

            try
            {
                var command = msConnection.CreateCommand();
                var msSql = string.Format("EXEC sys.sp_helpconstraint @objname = N'{0}.{1}', @nomsg = N'nomsg'", schema, tableName);
                command.CommandText = msSql;

                using (var dr = command.ExecuteReader(CommandBehavior.Default))
                {
                    while (dr.Read())
                    {
                        // 0 = constraint_type, 1 = constraint_name, 6 = constraint_keys.
                        object[] rowObjects = new object[7];
                        int result = dr.GetValues(rowObjects);
                        var constraintType = rowObjects[0].ToString();
                        constraintName = rowObjects[1].ToString();
                        constraintKeys = rowObjects[6].ToString();

                        // string str = constraintName + " / " + constraintType + " / " + constraintKeys;

                        if (constraintType.StartsWith("default on column "))
                        {
                            string columName = constraintType.Replace("default on column ", string.Empty);

                            // Remove the extra hooks ()
                            constraintKeys = constraintKeys.Remove(0, 1);
                            constraintKeys = constraintKeys.Remove(constraintKeys.Length - 1, 1);

                            constraintKeys = constraintKeys.Replace("newid()", "uuid_generate_v1()");

                            constraintKeys = constraintKeys.Replace("getdate()", "now()");

                            // boolean field ?
                            var found = fields.Find(x => x.StartsWith(columName));

                            if (!string.IsNullOrEmpty(found))
                            {
                                if (found.Contains(" bit "))
                                {
                                    constraintKeys = constraintKeys.Replace("(0)", "false");
                                    constraintKeys = constraintKeys.Replace("(1)", "true");
                                }
                            }

                            columName = columName.Replace(' ', '_');
                            string df = string.Format("alter table {0} alter column {1} set default {2};", pgTableName, columName, constraintKeys);
                            defaultsTemp.Add(df);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print("GetDefaults() " + ex.Message);
            }

            return defaultsTemp;
        }

        /// <summary>
        /// Get the ROWGUIDCOL and IDENTITY Columns for a table formatted in PostgreSQL style, example: 
        /// "alter table tablename alter column columnname set default uuid_generate_v1();"
        /// </summary>
        public static List<string> GetDefaults2(SqlConnection msConnection, string tableName, string schema)
        {
            var defaultsTemp = new List<string>();
            string pgTableName = schema + "." + tableName;
            pgTableName = pgTableName;

            try
            {
                var command = msConnection.CreateCommand();

                var msSql = string.Format(@"SELECT col.name, is_rowguidcol, is_identity
                                            FROM    sys.indexes ind
                                                    INNER JOIN sys.index_columns ic
                                                        ON ind.object_id = ic.object_id
                                                           AND ind.index_id = ic.index_id
                                                    INNER JOIN sys.columns col
                                                        ON ic.object_id = col.object_id
                                                           AND ic.column_id = col.column_id
                                                    INNER JOIN sys.tables t
                                                        ON ind.object_id = t.object_id
                                            WHERE   t.is_ms_shipped = 0 
                                                    AND (col.is_rowguidcol > 0 OR col.is_identity > 0)
                                                    AND OBJECT_SCHEMA_NAME(ind.object_id) = '{0}'
		                                            AND OBJECT_NAME(ind.object_id) = '{1}'
                                            ", schema, tableName);

                command.CommandText = msSql;

                using (var dr = command.ExecuteReader(CommandBehavior.Default))
                {
                    while (dr.Read())
                    {
                        // 0 = ColumnName, 1 = Rowguid, 2 = Identity.
                        object[] rowObjects = new object[3];
                        int result = dr.GetValues(rowObjects);
                        var columnName = rowObjects[0].ToString();
                        var isrowguidcol = rowObjects[1].ToString();
                        var isidentity = rowObjects[2].ToString();

                        if (!string.IsNullOrEmpty(columnName))
                        {
                            columnName = columnName.Replace(' ', '_');

                            if (isrowguidcol == "True")
                            {
                                // ROWGUIDCOL found for this table.
                                string df = string.Format("alter table {0} alter column {1} set default uuid_generate_v1();", pgTableName, columnName);
                                defaultsTemp.Add(df);
                            }
                            else if (isidentity == "True")
                            {
                                // IDENTITY found for this table, convert to "SERIAL" pseudo data type.
                                string seq1 = string.Format("create sequence {0}_{1}_seq;", pgTableName, columnName);
                                string df = string.Format("alter table {0} alter column {1} set default nextval('{0}_{1}_seq');", pgTableName, columnName);
                                string seq2 = string.Format("alter sequence {0}_{1}_seq owned by {0}.{1};", pgTableName, columnName);
                                defaultsTemp.Add(seq1);
                                defaultsTemp.Add(df);
                                defaultsTemp.Add(seq2);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print("GetDefaults2() " + ex.Message);
            }

            return defaultsTemp;
        }

        /// <summary>
        /// Get the PostgreSQL style fields for CREATE TABLE or VIEW from the SQL Server Schema Collections.
        /// Add primary key (if it exists).
        /// https://msdn.microsoft.com/en-us/library/ms254969(v=vs.110).aspx
        /// http://www.postgresql.org/docs/9.3/static/datatype.html
        /// </summary>
        public static string GetFieldInformation(SqlConnection msConnection, string msTablename, ref List<string> msColumns, ref string schema)
        {
            // 0 = Catalog; 1 = Schema; 2 = Table Name; 3 = Column Name. 
            var columnRestrictions = new string[4];
            // columnRestrictions[1] = schema;     // To filter on schema.
            columnRestrictions[2] = msTablename;
            DataTable dataColumns = msConnection.GetSchema("Columns", columnRestrictions);
            List<string> pgFields = new List<string>();
            string pgCreateFields;

            foreach (DataRow rowColumn in dataColumns.Rows)
            {
                string fieldCreate;
                schema = rowColumn["table_schema"].ToString();
                string columnName = rowColumn["column_name"].ToString().CapitalizeFirstLetter();
                string datatype = rowColumn["data_type"].ToString();
                string charlen = rowColumn["character_maximum_length"].ToString();
                string nullable = rowColumn["is_nullable"].ToString();
                // column_default
                // numeric_precision

                msColumns.Add(columnName);

                // Replace spaces by underscores in PostgreSQL field.
                columnName = columnName.Replace(' ', '_');

                // Only for tables.
                if (string.IsNullOrEmpty(charlen))
                {
                    fieldCreate = $"\"{ columnName}\"  {datatype}";
                }
                else if (charlen == "-1")
                {
                    fieldCreate = $"\"{ columnName}\"" + " " + datatype + "(max)";

                }
                else if (datatype == "binary" || datatype == "varbinary" || datatype == "image")
                {
                    // Will be converted to bytea, without (length).
                    fieldCreate = $"\"{ columnName}\"" + " " + datatype;
                }
                else
                {
                    fieldCreate = $"\"{ columnName}\"" + " " + datatype + "(" + charlen + ")";
                }

                if (nullable == "YES")
                {
                    fieldCreate += " NULL";
                }
                else
                {
                    fieldCreate += " NOT NULL";
                }

                // Console.WriteLine(fieldCreate);
                pgFields.Add(fieldCreate);
            }

            // Get the DEFAULTS and ROWGUIDCOL.
            var defaults1 = GetDefaults(msConnection, msTablename, pgFields, schema);

            var defaults2 = GetDefaults2(msConnection, msTablename, schema);

            if (defaults2.Count > 0)
            {
                defaults1.AddRange(defaults2);
            }

            defaults = defaults1.ToArray();

            // Add only primary key here, indexes are created later.
            indexes = GetIndexes(msConnection, msTablename, schema);

            if (indexes != null)
            {
                foreach (string index in indexes)
                {
                    if (index.StartsWith("constraint"))
                    {
                        Debug.Print("Primary key = " + index);
                        pgFields.Add(index);
                    }
                }
            }

            // Translate to PostgreSQL datatypes.
            pgCreateFields = string.Join(",", pgFields);
            pgCreateFields = pgCreateFields.Replace(" uniqueidentifier", " uuid");
            pgCreateFields = pgCreateFields.Replace(" nvarchar(max)", " text");
            pgCreateFields = pgCreateFields.Replace(" varchar(max)", " text");
            pgCreateFields = pgCreateFields.Replace(" nvarchar", " varchar");
            //pgCreateFields = pgCreateFields.Replace("varchar", "varchar");
            pgCreateFields = pgCreateFields.Replace(" nchar", " char");
            //pgCreateFields = pgCreateFields.Replace(" char", " char");
            pgCreateFields = pgCreateFields.Replace(" xml(max)", " text");
            pgCreateFields = pgCreateFields.Replace(" xml", " text");
            //pgCreateFields = pgCreateFields.Replace("bigint", "bigint");
            pgCreateFields = pgCreateFields.Replace(" tinyint", " smallint");
            //pgCreateFields = pgCreateFields.Replace(" float", " float");
            //pgCreateFields = pgCreateFields.Replace(" real", " real");
            pgCreateFields = pgCreateFields.Replace(" double", " double precision");
            //pgCreateFields = pgCreateFields.Replace("numeric", "numeric");
            pgCreateFields = pgCreateFields.Replace(" decimal", " numeric");
            pgCreateFields = pgCreateFields.Replace(" smallmoney", " numeric");
            pgCreateFields = pgCreateFields.Replace(" money", " numeric");
            pgCreateFields = pgCreateFields.Replace(" hierarchyid", " bytea");
            pgCreateFields = pgCreateFields.Replace(" geography", " bytea");
            pgCreateFields = pgCreateFields.Replace(" varbinary(max)", " bytea");
            pgCreateFields = pgCreateFields.Replace(" varbinary", " bytea");
            pgCreateFields = pgCreateFields.Replace(" binary", " bytea");
            pgCreateFields = pgCreateFields.Replace(" image", " bytea");
            pgCreateFields = pgCreateFields.Replace(" datetime2", " timestamptz");
            pgCreateFields = pgCreateFields.Replace(" datetime", " timestamptz");
            pgCreateFields = pgCreateFields.Replace(" int ", " integer ");
            pgCreateFields = pgCreateFields.Replace(" bit ", " boolean ");

            return pgCreateFields;
        }

        /// <summary>
        /// Create all views for catalog, e.g. AdventureWorksLT2008R2.
        /// Note: for AdventureWorksLT2008R2 only 1 of the 3 views can be converted.
        /// </summary>
        public static void CreateViews(string connectionStringSqlServer, string connectionStringPostgresql)
        {
            Console.WriteLine(@"Creating Views ...");

            using (var cn = new SqlConnection(connectionStringSqlServer))
            {
                // SELECT [VIEW_DEFINITION] FROM [AdventureWorksLT2008R2].[INFORMATION_SCHEMA].[VIEWS]
                var msSql = string.Format(@"SELECT [VIEW_DEFINITION] FROM [{0}].[INFORMATION_SCHEMA].[VIEWS]", Catalog);
                Debug.Print(msSql);
                cn.Open();
                var command = cn.CreateCommand();
                command.CommandText = msSql;

                using (var dr = command.ExecuteReader(CommandBehavior.Default))
                {
                    if (!dr.HasRows)
                    {
                        Console.WriteLine(@"No views.");
                    }

                    object[] rowObjects = new object[1];

                    // Read values from source db, e.g.
                    // CREATE VIEW [SalesLT].[vProductAndDescription]   WITH SCHEMABINDING   AS   SELECT   p.[ProductID]   ,p.[Name]   ,pm.[Name] AS [ProductModel]   ,pmx.[Culture]   ,pd.[Description]   FROM [SalesLT].[Product] p   INNER JOIN [SalesLT].[ProductModel] pm   ON p.[ProductModelID] = pm.[ProductModelID]   INNER JOIN [SalesLT].[ProductModelProductDescription] pmx   ON pm.[ProductModelID] = pmx.[ProductModelID]   INNER JOIN [SalesLT].[ProductDescription] pd   ON pmx.[ProductDescriptionID] = pd.[ProductDescriptionID];  
                    while (dr.Read())
                    {
                        int result = dr.GetValues(rowObjects);
                        var pgSql = rowObjects[0].ToString();
                        Debug.Print(string.Empty);
                        Debug.Print(pgSql);

                        pgSql = pgSql.Replace("WITH SCHEMABINDING", string.Empty);
                        pgSql = pgSql.Replace("[", string.Empty);
                        pgSql = pgSql.Replace("]", string.Empty);
                        pgSql = pgSql;

                        var pgArr = pgSql.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                        Console.WriteLine(pgArr[0]);
                        Console.WriteLine(string.Empty);

                        // Try to create view in target db..
                        if (!ExecuteSqlScript(connectionStringPostgresql, pgSql))
                        {
                            Console.WriteLine(string.Empty);
                            Console.WriteLine(@"Error: view could not be created !");
                            Console.WriteLine(string.Empty);
                        }
                    }

                    Console.WriteLine(string.Empty);
                }
            }
        }

        /// <summary>
        /// Create PostgreSQL foreign keys, this needs to be done as a last step to avoid conflicts.
        /// </summary>
        public static void CreateForeignKeys(string connectionStringSqlServer, string connectionStringPostgresql)
        {
            Console.WriteLine(@"Creating Foreign Keys ...");
            var fkStatements = GetForeignKeyInformation(connectionStringSqlServer);

            if (fkStatements.Length < 1)
            {
                Console.WriteLine(@"No Foreign Keys.");
            }

            foreach (string fkStatement in fkStatements)
            {
                ExecuteSqlScript(connectionStringPostgresql, fkStatement);
            }
        }

        /// <summary>
        /// Get foreign key information from SQL Server.
        /// Return PostgreSQL ALTER TABLE statements array.
        /// </summary>
        /// <param name="connectionString">The SQL Server connection String.</param>
        /// <returns>string array.</returns>
        public static string[] GetForeignKeyInformation(string connectionString)
        {
            var pgStatements = new List<string>();

            using (var cn = new SqlConnection(connectionString))
            {
                cn.Open();
                var command = cn.CreateCommand();
                command.CommandText = @"
BEGIN
	DECLARE @tbl_foreign_key_columns TABLE ( constraint_name NVARCHAR(128),
											 base_schema_name NVARCHAR(128),
											 base_table_name NVARCHAR(128),
											 base_column_id INT,
											 base_column_name NVARCHAR(128),
											 unique_schema_name NVARCHAR(128),
											 unique_table_name NVARCHAR(128),
											 unique_column_id INT,
											 unique_column_name NVARCHAR(128),
											 base_object_id INT,
											 unique_object_id INT )
	INSERT  INTO @tbl_foreign_key_columns ( constraint_name, base_schema_name, base_table_name, base_column_id, base_column_name, unique_schema_name, unique_table_name, unique_column_id, unique_column_name, base_object_id, unique_object_id )
			SELECT  FK.name AS constraint_name, S.name AS base_schema_name, T.name AS base_table_name, C.column_id AS base_column_id, C.name AS base_column_name, US.name AS unique_schema_name, UT.name AS unique_table_name, UC.column_id AS unique_column_id, UC.name AS unique_column_name, T.[object_id], UT.[object_id]
			FROM    sys.tables AS T
			INNER JOIN sys.schemas AS S
			ON      T.schema_id = S.schema_id
			INNER JOIN sys.foreign_keys AS FK
			ON      T.object_id = FK.parent_object_id
			INNER JOIN sys.foreign_key_columns AS FKC
			ON      FK.object_id = FKC.constraint_object_id
			INNER JOIN sys.columns AS C
			ON      FKC.parent_object_id = C.object_id
					AND FKC.parent_column_id = C.column_id
			INNER JOIN sys.columns AS UC
			ON      FKC.referenced_object_id = UC.object_id
					AND FKC.referenced_column_id = UC.column_id
			INNER JOIN sys.tables AS UT
			ON      FKC.referenced_object_id = UT.object_id
			INNER JOIN sys.schemas AS US
			ON      UT.schema_id = US.schema_id
			ORDER BY base_schema_name, base_table_name
END

SELECT base_schema_name, base_table_name, constraint_name, base_column_name, unique_table_name, unique_column_name FROM @tbl_foreign_key_columns
";

                var dr = command.ExecuteReader();

                while (dr.Read())
                {
                    var baseSchemaName = dr.GetValue(0).ToString();
                    var baseTableName = dr.GetValue(1).ToString();
                    var constraintName = dr.GetValue(2).ToString();
                    var baseColumnName = dr.GetValue(3).ToString();
                    var uniqueTableName = dr.GetValue(4).ToString();
                    var uniqueColumnName = dr.GetValue(5).ToString();
                    //Debug.Print(base_table_name);
                    //Debug.Print(constraint_name);

                    var pgTableName = $"{baseSchemaName}.\"{baseTableName}\"";
                    pgTableName = pgTableName.Replace(" ", "_");

                    var pguniqueTableName = $"{baseSchemaName}.\"{uniqueTableName}\"";
                    pguniqueTableName = pguniqueTableName.Replace(" ", "_");

                    //string fkSkip = @"|fk_xxxxxxxxxxx|fk_yyyyyyyyyyyyyyyyyyyyyy|";

                    //if (fkSkip.Contains("|" + constraintName + "|"))
                    //{
                    //    Debug.Print(@"Skipping: " + constraintName);
                    //}
                    //else
                    {
                        var sqlFk = $"ALTER TABLE {pgTableName} ADD CONSTRAINT \"{constraintName}\" FOREIGN KEY(\"{baseColumnName}\") REFERENCES {pguniqueTableName} (\"{uniqueColumnName}\");";
                        Debug.Print(sqlFk);
                        pgStatements.Add(sqlFk);
                    }
                }

                Debug.Print(string.Empty);
            }

            return pgStatements.ToArray();
        }

        /// <summary>
        /// Execute an SQL Server or PostgreSQL command.
        /// Note: does not execute a script with "GO" statements.
        /// </summary>
        /// <param name="connectionString">The connectionString.</param>
        /// <param name="sqlClause">The sql command.</param>
        /// <returns>True on success.</returns>
        public static bool ExecuteSqlScript(string connectionString, string sqlClause)
        {
            bool result = false;
            LastErrror = string.Empty;

            if (IsPostgresql(connectionString))
            {
                using (var cn = new NpgsqlConnection(connectionString))
                {
                    using (var cmd = new NpgsqlCommand(sqlClause, cn))
                    {
                        try
                        {
                            if (cn.State != System.Data.ConnectionState.Open)
                            {
                                cn.Open();
                            }

                            cmd.ExecuteNonQuery();
                            result = true;
                        }
                        catch (Exception ex)
                        {
                            LastErrror = ex.Message;
                            Debug.Print("ExecuteSqlScript() error: " + ex.Message);
                            Console.WriteLine("ExecuteSqlScript() error: " + ex.Message);
                        }
                        finally
                        {
                            cn.Close();
                        }
                    }
                }
            }
            else
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand(sqlClause, cn))
                    {
                        try
                        {
                            if (cn.State != System.Data.ConnectionState.Open)
                            {
                                cn.Open();
                            }

                            cmd.ExecuteNonQuery();
                            result = true;
                        }
                        catch (Exception ex)
                        {
                            LastErrror = ex.Message;
                            Debug.Print("ExecuteSqlScript() error: " + ex.Message);
                            Console.WriteLine("ExecuteSqlScript() error: " + ex.Message);
                        }
                        finally
                        {
                            cn.Close();
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Execute a parameterized query.
        /// </summary>
        private static void CopyToPostgreSql2(string pgConnection, string query, List<string> columnList, object[] objects)
        {
            int result = 0;

            using (var connectionNpgsql = new NpgsqlConnection(pgConnection))
            {
                result = ExecuteParameterQuery(connectionNpgsql, query, columnList, objects);
            }

            if (result < 1)
            {
                Console.WriteLine("Error: " + query);
            }
        }

        /// <summary>
        /// Execute PostgreSQL parameterized query, e.g. to insert a record, a connection must already be opened.
        /// </summary>
        public static int ExecuteParameterQuery(NpgsqlConnection connectionNpgsql, string query, List<string> columnList, object[] objects)
        {
            int result = 0;

            try
            {
                using (var command = new NpgsqlCommand(query, connectionNpgsql))
                {
                    if (objects != null)
                    {
                        // Add parameterized objects for all fields.
                        for (int i = 0; i < columnList.Count; i++)
                        {
                            var columnName = columnList[i];
                            var obj = objects[i];

                            if (obj is Enum)
                            {
                                command.Parameters.AddWithValue(columnName, NpgsqlDbType.Integer, obj);
                            }
                            else
                            {
                                command.Parameters.AddWithValue(columnName, obj);
                            }
                        }
                    }

                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LastErrror = ex.Message;
                Debug.Print(LastErrror);
            }

            return result;
        }

        /// <summary>
        /// Get SQL Server connection string.
        /// </summary>
        /// <param name="sqlServer">The sql server.</param>
        /// <param name="catalog">The catalog.</param>
        /// <param name="username">The username (empty for Windows Authentication).</param>
        /// <param name="password">The password (empty for Windows Authentication).</param>
        /// <returns> The connection string.</returns>
        public static string GetConnectionString(string sqlServer, string catalog, string username, string password)
        {
            string connectionString;

            if (username.Equals(string.Empty))
            {
                connectionString = string.Format(@"Integrated Security=SSPI;Persist Security Info=False;Data Source={0}", sqlServer);
            }
            else if (username.Contains("\\"))
            {
                connectionString = string.Format(@"Password={0};User ID={1};Integrated Security=SSPI;Persist Security Info=True;Data Source={2}", password, username, sqlServer);
            }
            else
            {
                connectionString = string.Format(@"Password={0};Persist Security Info=True;User ID={1};Data Source={2}", password, username, sqlServer);
            }

            connectionString = @"Connection Timeout=15;" + connectionString;

            if (!catalog.Equals(string.Empty))
            {
                // add the catalog
                connectionString += ";Initial Catalog=" + catalog;
            }

            return connectionString;
        }

        /// <summary>
        /// Get connection string with ProviderName and port, e.g. "Npgsql" and 5432 for PostgreSQL.
        /// </summary>
        /// <param name="server">The server, e.g. "(local)" for SQL Server, "127.0.0.1" for PostgreSQL.</param>
        /// <param name="catalog">The catalog.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="providername">ProviderName: "System.Data.SqlClient" or empty for SQL Server, "Npgsql" for PostgreSQL</param>
        /// <param name="port">The port, e.g. 5432 for PostgreSQL.</param>
        /// <returns> The connection string.</returns>
        public static string GetConnectionString(string server, string catalog, string username, string password, string providername, int port)
        {
            string connectionString;

            if (string.IsNullOrEmpty(providername))
            {
                providername = "System.Data.SqlClient";
            }

            if (providername == @"System.Data.SqlClient")
            {
                // Get SQL Server string, port is not used.
                connectionString = GetConnectionString(server, catalog, username, password);
            }
            else if (providername == @"Npgsql")
            {
                // PostgreSQL example:
                // Server=127.0.0.1;Port=5432;User Id=postgres;Password=postgres;MinPoolSize=8;MaxPoolSize=80;CommandTimeout=20;Database=postgrestest
                if (string.IsNullOrEmpty(catalog))
                {
                    catalog = @"postgres";
                }

                // Set default CommandTimeout of 20 s. 
                connectionString = string.Format(
                    "Server={0};Port={1};User Id={2};Password={3};MinPoolSize={4};MaxPoolSize={5};CommandTimeout={6};Database={7}",
                    server,
                    port,
                    username,
                    password,
                    Environment.ProcessorCount,
                    Environment.ProcessorCount * 10,
                    20,
                    catalog);
            }
            else
            {
                string errorMessage = @"GetConnectionString() failed, unknown providername: " + providername;
                throw new Exception(errorMessage);
            }

            return connectionString;
        }

        /// <summary>
        /// Delete SQL Server or PostgreSQL database.
        /// </summary>
        /// <param name="connectionStringWithoutCatalog">The connection string without catalog.</param>
        /// <param name="catalog">The catalog.</param>
        public static void DeleteDatabase(string connectionStringWithoutCatalog, string catalog)
        {
            if (IsPostgresql(connectionStringWithoutCatalog))
            {
                // PostgreSQL, note that the database name must be in lower case.
                NpgsqlConnection.ClearAllPools();

                using (var sqlConn = new NpgsqlConnection(connectionStringWithoutCatalog))
                {
                    sqlConn.Open();
                    using (var command = new NpgsqlCommand(string.Format("DROP DATABASE \"{0}\";", catalog), sqlConn))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                return;
            }

            // SQL Server.
            using (var connection = new SqlConnection(connectionStringWithoutCatalog))
            {
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    string sqlString;
                    if (connection.Database.Equals("master"))
                    {
                        sqlString = string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [{0}];", catalog);
                    }
                    else
                    {
                        sqlString = string.Format("USE Master; ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [{0}];", catalog);
                    }

                    Debug.Print(sqlString);
                    var command = new SqlCommand(sqlString, connection);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public static class Extension
    {
        public static string CapitalizeFirstLetter(this string text)
        {
            return text.First().ToString().ToUpper() + string.Join("", text.Skip(1));
        }
    }
}
