﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codium.Interview.EmployeeEvidenceApp.Shared.Models.Exceptions
{
    /// <summary>
    /// Exception thrown when there is an error in the employee repository (query returns null)
    /// </summary>
    public class EmployeeRepositoryException : Exception
    {
    }
}
