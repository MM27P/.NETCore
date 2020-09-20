using StaffApp.Database.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StaffApp.Database.Models
{
    [Table("Emplyoees")]
    public class Employee
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }

        public Position Position
        {
            get
            {
                if (PositionName == null)
                    return Position.None;
                return Enum.Parse<Position>(PositionName);
            }
            set
            {
                PositionName = Position.ToString();
            }
        }

        private string PositionName { get; set; }

        public long CompanyId { get; set; }
    }
}
