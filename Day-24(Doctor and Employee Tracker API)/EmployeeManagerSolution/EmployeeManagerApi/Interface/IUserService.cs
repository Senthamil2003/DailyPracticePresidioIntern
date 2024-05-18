using EmployeeManagerApi.Model;
using EmployeeManagerApi.Model.DTO;

namespace EmployeeManagerApi.Interface
{
    public interface IUserService
    {
        public Task<SuccessRequest> RaiseRequest(RaiseRequestDTO raiser);
        public Task<IList<RequestListDTO>> GetMyRequests(ViewRequestDTO viewer);


    }
}
