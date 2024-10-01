using Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs
{
    public class EmployeeDTO
    {
        public int EployeeID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\u00C0-\u017F]+$", ErrorMessage = "Name must contain only letters.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\u00C0-\u017F]+$", ErrorMessage = "Surame must contain only letters.")]
        public string Surname { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int? PositionID { get; set; }
        [Required]
        [RegularExpression(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$", ErrorMessage = "Invalid IP address format.")]
        public string IPaddress { get; set; }
        public string IPCountryCode { get; set; }
    }
}
