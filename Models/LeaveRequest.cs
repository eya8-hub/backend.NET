﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssements.Core.Models
{
   
        public enum LeaveType
        {
            Annual,
            Sick,
            Other
        }

        public enum LeaveStatus
        {
            Pending,
            Approved,
            Rejected
        }

        public class LeaveRequest
        {
            public int Id { get; set; }
            public int EmployeeId { get; set; }              
            public LeaveType LeaveType { get; set; }         
            public DateTime StartDate { get; set; }        
            public DateTime EndDate { get; set; }           
            public LeaveStatus Status { get; set; }         
            public  string Reason { get; set; }               
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

            // Navigation property
            public   Employee? Employee { get; set; }
        }
    }



