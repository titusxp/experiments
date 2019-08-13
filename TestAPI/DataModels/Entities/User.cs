using System.ComponentModel.DataAnnotations;

namespace DataModels.Entities
{
    public class User
    {
        [Key]
        [StringLength(200)]
        public string Username { get; set; }

        [StringLength(200)]
        public string Password { get; set; }
    }
}
