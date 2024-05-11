using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerBLLibrary.Services
{
    public interface RequestService
    {
        public Task<Request> RaiseRequest(Request request);
        public Task<Request> CheckStatus(int id);
        public Task<List<Request>> RequestList();
        public Task<Request> UpdateProblemStatus(int id);
        public Task<Request> UpdateRequestStatus(int id);
       
    }
}
