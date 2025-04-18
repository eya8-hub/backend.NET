using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace TechnicalAssements.Core.Models
{
          public class Employee
        {
            public int Id { get; set; }                    
            public required string FullName { get; set; }
            public required string Department { get; set; }           
            public DateTime JoiningDate { get; set; }       

            // Navigation property - un employé peut avoir plusieurs demandes
            public required ICollection<LeaveRequest> LeaveRequests { get; set; }
        }
    }



