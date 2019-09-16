using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.Models
{
    public class Department
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}