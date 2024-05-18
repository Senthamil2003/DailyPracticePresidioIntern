using EmployeeManagerApi.CustomExceptions;
using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;
using EmployeeManagerApi.Model.DTO;

namespace EmployeeManagerApi.Services
{
    public class AdminService:IAdminService
    {
        private readonly IReposiroty<int, User> _userservice;
        private readonly IReposiroty<int, Employee> _employeeservice;
        private readonly IReposiroty<int, Request> _requestservice;

        public AdminService(IReposiroty<int ,Employee> employeeservice,IReposiroty<int,User> userservice,IReposiroty<int,Request> requestservice) {
            _userservice=userservice;
            _employeeservice=employeeservice;
            _requestservice=requestservice;
        }   
        public async Task<SuccessActivation> ActiveEmployee(int EmployeeId)
        {
            try
            {
              User user= await _userservice.Get(EmployeeId);
                if (user.Status == "Enable")
                {
                    throw new UserAlreadyActivatedException("User is already activated");
                }
                user.Status = "Enable";
               await  _userservice.Update(user);
                Employee employee=await _employeeservice.Get(EmployeeId);
                SuccessActivation successActivation = new SuccessActivation()
                {
                    Code = 200,
                    Message = "Activation successful",
                    EmployeeId =employee.EmployeeId,
                    EmployeeName =employee.Name,
                    Role =employee.Role

                };
                return successActivation;
              
            }
            catch
            {
                throw;
            }
        }

        public async Task<IList<Request>> GetAllRequest()
        {
            try
            {
                List<Request> requests = (await _requestservice.Get()).Where(r => r.RequestStatus == "Open").OrderByDescending(r=>r.RaiseDate).ToList();
                if(requests.Count > 0)
                {
                    return requests;

                }
                
                throw new NoRequestFoundException("No Request is Open");


            }
            catch
            {
                throw;

            }

        }
        public async Task<SuccessRequestClose> CloseRequest(int RequestId)
        {
            try
            {
               Request request=await  _requestservice.Get(RequestId);
                if (request == null)
                {
                    throw new NoRequestFoundException("No request found for the given Id");
                }
                request.RequestStatus= "Close";
                await _requestservice.Update(request);
                SuccessRequestClose requestClose = new SuccessRequestClose()
                {
                    Code = 200,
                    Message = "Request Closed Successfully",
                    RequestId = RequestId
                };
                return requestClose;
            }
            catch
            {
                throw ;
            }
        }
    }
}
