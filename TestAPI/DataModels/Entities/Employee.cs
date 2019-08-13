using System;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Entities
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        public DateTime DateOrBirth { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

    }
}
