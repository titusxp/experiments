using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace TestMigration.Classes
{
    public class Person
    {
        [Key]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}
