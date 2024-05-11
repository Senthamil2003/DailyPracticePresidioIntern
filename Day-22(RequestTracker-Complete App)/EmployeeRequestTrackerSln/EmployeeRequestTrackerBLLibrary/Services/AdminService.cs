using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerBLLibrary.Services
{
    public interface AdminService:UserService
    {
        public Task<List<Solution>> GivenSolutions(int id);
        public Task<List<Request>> GetClosedList(int id);
        public Task<List<Request>> RequestList();
        public Task<Request> UpdateRequestStatus(int id);

    }
}
