using EmployeeManagerApi.CustomExceptions;
using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;
using EmployeeManagerApi.Model.DTO;

namespace EmployeeManagerApi.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IReposiroty<int, Employee> _employeerepo;
        private readonly IReposiroty<int, Request> _requestrepo;

        public UserService(IReposiroty<int, Employee> employeeRepo, IReposiroty<int, Request> requestrepo)
        {
            _employeerepo = employeeRepo;
            _requestrepo = requestrepo;
        }
        public async Task<SuccessRequest> RaiseRequest(RaiseRequestDTO raiser)
        {
            try
            {
                Employee employee = await _employeerepo.Get(raiser.EmployeeId);
                if (employee == null)
                {
                    throw new NoEmployeeFoundException();
                }
                Request request = new Request()
                {
                    EmployeeId = raiser.EmployeeId,
                    Statement = raiser.Problem
                };
                Request result = await _requestrepo.Add(request);
                SuccessRequest successRequest = new SuccessRequest()
                {
                    Code = 200,
                    Message = "Request added successfully",
                    RequestId = result.RequestId,
                };
                return successRequest;

            }
            catch
            {
                throw;
            }
        }
        public async Task<IList<RequestListDTO>> GetMyRequests(ViewRequestDTO viewer)
        {

            try
            {
                Employee employee = await _employeerepo.Get(viewer.EmployeeId);
                if (employee.RaisedRequest.Count > 0)
                {
                    var result = employee.RaisedRequest.ToList();
                    RequestListDTO[] requestLists= new RequestListDTO[result.Count];
                    for(int i=0;i<result.Count; i++)
                    {
                        var request = result[i];
                        requestLists[i] = new RequestListDTO 
                        {
                            RequestId = request.RequestId,
                            Problem = request.Statement,
                            Status = request.RequestStatus,
                            RaisedDate = request.RaiseDate,
                            RaisedById = request.EmployeeId
                        };

                    }
                    return requestLists;

                }
                throw new NoRequestFoundException("No Request raised");


            }
            catch
            {
                throw;

            }
        }

    }
}
