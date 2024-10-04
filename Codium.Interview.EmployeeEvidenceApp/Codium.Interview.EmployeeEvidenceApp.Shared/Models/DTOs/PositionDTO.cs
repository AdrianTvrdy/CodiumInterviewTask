using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codium.Interview.EmployeeEvidenceApp.Shared.Models.DTOs
{
    /// <summary>
    /// Data Transfer Object for Position entity
    /// </summary>
    public class PositionDTO
    {
        public int PositionID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\u00C0-\u017F]+$", ErrorMessage = "Name must contain only letters.")]
        public string PositionName { get; set; }

    }
}
