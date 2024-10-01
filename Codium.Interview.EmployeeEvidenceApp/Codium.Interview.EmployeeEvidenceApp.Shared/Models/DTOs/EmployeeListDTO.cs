using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs
{
    /// <summary>
    /// Data Transfer Object for Employee entity displayed in the all employees list
    /// </summary>
    public class EmployeeListDTO
    {
        public int EployeeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
