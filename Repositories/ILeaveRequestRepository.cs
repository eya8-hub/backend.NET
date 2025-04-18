using LeaveManagementSystem.Repositories;
using TechnicalAssements.Core.Models;

namespace LeaveManagementSystem.Repositories
    {
        public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
        {
            Task<IEnumerable<LeaveRequest>> GetByEmployeeAsync(int employeeId);
        }
    }


