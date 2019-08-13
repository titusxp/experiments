namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Guid(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 200),
                        DateOrBirth = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 200),
                        Password = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Employees");
        }
    }
}
