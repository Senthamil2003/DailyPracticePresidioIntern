using EmployeeRequestTrackerBLLibrary.Services;
using EmployeeRequestTrackerDALLibrary;
using RequestRequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerBLLibrary
{
    public class RequestBl : RequestService
    {
        readonly IRepository<int, Request> _requestrepo;
        public RequestBl() {
            _requestrepo = new RequestRepository(new RequestTrackerContext());
        }
        public async Task<Request> CheckStatus(int id)
        {
            return await _requestrepo.Get(id);
            
        }

        public async Task<Request> CreateRequest(Request request)
        {
            await _requestrepo.Add(request);
            return request;
        }
    }
}
