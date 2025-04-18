namespace TechnicalAssesments.API.DTOs
{
    public class CreateLeaveRequestDTO
    {
        public int EmployeeId { get; set; }
        public string? LeaveType { get; set; } = string.Empty; // Annual, Sick, Other
        public string? LeaveStatus { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Reason { get; set; }


    }
}

        
