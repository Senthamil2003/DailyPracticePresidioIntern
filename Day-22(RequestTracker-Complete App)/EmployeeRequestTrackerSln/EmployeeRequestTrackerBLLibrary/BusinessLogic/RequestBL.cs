using EmployeeRequestTrackerBLLibrary.Services;
using EmployeeRequestTrackerDALLibrary;
using EmployeeRequestTrackerDALLibrary.Repository;

using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerBLLibrary.BusinessLogic
{
    public class RequestBL : RequestService
    {
        readonly IRepository<int, Request> _requestrepo;
        public RequestBL()
        {
            _requestrepo = new RequestRepository(new RequestTrackerContext());
        }
        public async Task<Request> CheckStatus(int id)
        {
            try
            {
                Request request = await _requestrepo.Get(id);
                if (request != null)
                {
                    return request;
                }
                throw new NoDataFoundException("No request found for the given Id");
            }
            catch
            {
                throw;
            }



        }
        public async Task<Request> RaiseRequest(Request request)
        {
            try
            {
                await _requestrepo.Add(request);
                return request;
            }
            catch
            {
                throw;
            }

        }

        public async Task<List<Request>> RequestList()
        {
            try
            {
                List<Request> requests = await _requestrepo.GetAll();
                return requests;

            }
            catch
            {
                throw;
            }
        }

        public async Task<Request> UpdateProblemStatus(int id)
        {
            try
            {
                Request request = await _requestrepo.Get(id);
                request.ProblemStatus =true;
                await _requestrepo.Update(request);
                return request;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Request> UpdateRequestStatus(int id)
        {
            try
            {
                Request request = await _requestrepo.Get(id);
                request.RequestStatus = "Closed";
                await _requestrepo.Update(request);
                return request;

            }
            catch
            {
                throw;
            }
        }

    }
}
