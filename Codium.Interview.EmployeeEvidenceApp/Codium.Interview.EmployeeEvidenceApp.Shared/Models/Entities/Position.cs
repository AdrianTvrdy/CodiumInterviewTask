using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codium.Interview.EmployeeEvidenceApp.Shared.Models.Entities
{
    /// <summary>
    /// Entity representing a position in the company
    /// </summary>
    public class Position
    {
        [Key]
        public int PositionID { get; set; }
        public required string PositionName { get; set; }

    }
}
