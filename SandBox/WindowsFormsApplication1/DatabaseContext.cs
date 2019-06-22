using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WindowsFormsApplication1
{
    public class Car
    {
        [Key] public string Id { get; set; }
        public string Name { get; set; }
    }
    public class CarContext : DbContext
    {
        private DbSet<Car> Cars { get; set; }
    }
}