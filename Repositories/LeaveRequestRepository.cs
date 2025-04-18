using LeaveManagementSystem.Repositories;
using TechnicalAssements.Core.Models;
using Microsoft.EntityFrameworkCore;
using TechnicalAssesments.API.Data;

namespace TechnicalAssesments.API.Repositories
{
   

    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<LeaveRequest>> GetByEmployeeAsync(int employeeId)
        {
            return await _dbSet
                .Where(lr => lr.EmployeeId == employeeId)
                .Include(lr => lr.Employee)
                .ToListAsync();
        }
    }
}

