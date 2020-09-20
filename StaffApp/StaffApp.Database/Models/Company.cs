using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffApp.Database.Models
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public int EstablishYear { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
