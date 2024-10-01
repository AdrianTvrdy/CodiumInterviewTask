using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities
{
    /// <summary>
    /// Entity representing an employee in the company
    /// </summary>
    public class Employee
    {
        [Key]
        public int EployeeID { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        [ForeignKey("Position")] 
        public int? PositionID { get; set; } 
        public required DateTime BirthDate { get; set; }
        public Position? Position { get; set; }
        public required string IPaddress { get; set; }
        public required string IPCountryCode { get; set; }

    }
}
