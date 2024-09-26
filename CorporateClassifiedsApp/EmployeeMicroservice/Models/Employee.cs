using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMicroservice.Models
{
    //[Table]
    public class Employee
    {
        [Key,Required]
        public int EmpId { get; set; }

        [Required,MaxLength(50)]
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Points { get; set; }

        [Required, MaxLength(10)]
        public long MobileNum { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime DOB { get; set; }
    }
}
