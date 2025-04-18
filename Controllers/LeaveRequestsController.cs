using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalAssesments.API.Data;
using TechnicalAssements.Core.Models;
using TechnicalAssesments.API.DTOs;

namespace TechnicalAssesments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LeaveRequestsController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET all leave requests
        [HttpGet (Name="GetLeaveRequests")]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> GetLeaveRequests()
        {
            return await _context.LeaveRequest
                .Include(l => l.Employee) // optionnel si tu veux inclure les données d’employé
                .ToListAsync();
        }

        // ✅ GET leave request by id
        [HttpGet("{id}", Name = "GetLeaveRequestById")]
        public async Task<ActionResult<LeaveRequest>> GetLeaveRequest(int id)
        {
            var leaveRequest = await _context.LeaveRequest
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (leaveRequest == null)
            {
                return Ok(new { message = "The ID in the URL does not exist" });

            }

            return leaveRequest;
        }

        // ✅ POST a new leave request
        [HttpPost(Name = "CreateLeaveRequest")]
        public async Task<ActionResult<LeaveRequest>> PostLeaveRequest(CreateLeaveRequestDTO dto)
        {
            var leaveRequest = new LeaveRequest
            {
                EmployeeId = dto.EmployeeId,
                LeaveType = Enum.Parse<LeaveType>(dto.LeaveType),
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Reason = dto.Reason,
                CreatedAt = DateTime.UtcNow,
                Status = LeaveStatus.Pending
            };

            _context.LeaveRequest.Add(leaveRequest);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetLeaveRequestById", new { id = leaveRequest.Id }, leaveRequest);
        }


        // ✅ PUT to update a leave request
        [HttpPut("{id}", Name = "UpdateLeaveRequest")]
        public async Task<IActionResult> PutLeaveRequest(int id, LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.Id)
            {
              return  Ok(new { message = "The ID in the URL does not match the request body." });
            }

           

            _context.Entry(leaveRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaveRequestExists(id))
                {
                    return Ok(new { message = "$\"Leave request with ID {id} was not found.\"" });

                }
                else
                {
                    throw;
                }
            }

            return Ok(new { message = "Leave request updated successfully." });
        }

        // ✅ DELETE a leave request
        [HttpDelete("{id}", Name = "DeleteLeaveRequest")]
        public async Task<IActionResult> DeleteLeaveRequest(int id)
        {
            var leaveRequest = await _context.LeaveRequest.FindAsync(id);
            if (leaveRequest == null)
            {
                return Ok(new { message = "Leave request not  exist." });
            }

            _context.LeaveRequest.Remove(leaveRequest);
            await _context.SaveChangesAsync();
           
        
            return Ok(new { message = "Leave request Deleted successfully." });
        }

        private bool LeaveRequestExists(int id)
        {
            return _context.LeaveRequest.Any(e => e.Id == id);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<LeaveRequest>>> FilterLeaveRequests(
    int? employeeId,
    string? leaveType,
    string? status,
    DateTime? startDate,
    DateTime? endDate,
    string? keyword,
    string? sortBy = "StartDate",
    string? sortOrder = "asc",
    int page = 1,
    int pageSize = 10)
        {
            var query = _context.LeaveRequest
                .Include(l => l.Employee)
                .AsQueryable();

            // 🔎 Filtrage dynamique
            if (employeeId.HasValue)
                query = query.Where(l => l.EmployeeId == employeeId.Value);

            if (!string.IsNullOrEmpty(leaveType))
            {
                if (Enum.TryParse<LeaveType>(leaveType, out var parsedLeaveType))
                {
                    query = query.Where(l => l.LeaveType == parsedLeaveType);
                }
            }


            if (!string.IsNullOrEmpty(status))
            {
                if (Enum.TryParse<LeaveStatus>(status, out var parsedStatus))
                {
                    query = query.Where(l => l.Status == parsedStatus);
                }
            }

            if (startDate.HasValue)
                query = query.Where(l => l.StartDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(l => l.EndDate <= endDate.Value);

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(l => l.Reason.Contains(keyword));


            //  Maximum 20 jours annuels 
            if (leaveType == "0" && employeeId.HasValue)
            {
                var currentYear = DateTime.Now.Year;
                var totalDays = await _context.LeaveRequest
                    .Where(l => l.EmployeeId == employeeId.Value && l.LeaveType == LeaveType.Annual && l.StartDate.Year == currentYear)
                    .SumAsync(l => EF.Functions.DateDiffDay(l.StartDate, l.EndDate));

                if (totalDays > 20)
                    return Ok(new { message = "L’employé a dépassé les 20 jours annuels autorisés." });
            }

            // 🔒 Sick leave requires a non-empty reason
            if (leaveType == "1")
                query = query.Where(l => !string.IsNullOrEmpty(l.Reason));

            // ↕️ Tri dynamique
            query = sortOrder.ToLower() == "desc"
                ? query.OrderByDescending(e => EF.Property<object>(e, sortBy))
                : query.OrderBy(e => EF.Property<object>(e, sortBy));

            // 📄 Pagination
            var totalItems = await query.CountAsync();
            var results = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                totalItems,
                currentPage = page,
                totalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                data = results
            });
        }





        [HttpGet("report")]
        public async Task<IActionResult> GetLeaveSummaryReport(int year, string? department, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.LeaveRequest
                .Include(l => l.Employee)
                .Where(l => l.StartDate.Year == year)
                .AsQueryable();

            if (!string.IsNullOrEmpty(department))
                query = query.Where(l => l.Employee.Department == department);

            if (startDate.HasValue)
                query = query.Where(l => l.StartDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(l => l.EndDate <= endDate.Value);

            var report = await query
                .GroupBy(l => l.Employee.FullName)
                .Select(g => new
                {
                    Employee = g.Key,
                    TotalLeaves = g.Count(),
                    AnnualLeaves = g.Count(l => l.LeaveType == LeaveType.Annual),
                    SickLeaves = g.Count(l => l.LeaveType == LeaveType.Sick)
                })
                .ToListAsync();

            return Ok(report);
        }


        [HttpGet("{id}/approve")]
        public async Task<IActionResult> ApproveLeaveRequest(int id)
        {
            var leaveRequest = await _context.LeaveRequest.FindAsync(id);
            if (leaveRequest == null)
                return NotFound();

            if (leaveRequest.Status != LeaveStatus.Pending)
                return BadRequest(new { message = "Only pending requests can be approved." });

            leaveRequest.Status = LeaveStatus.Approved;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Leave request approved successfully." });
        }


    }



}
