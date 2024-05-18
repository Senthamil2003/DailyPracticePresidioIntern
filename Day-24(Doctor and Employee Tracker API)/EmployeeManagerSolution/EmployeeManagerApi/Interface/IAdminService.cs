using EmployeeManagerApi.Model;
using EmployeeManagerApi.Model.DTO;

namespace EmployeeManagerApi.Interface
{
    public interface IAdminService
    {
        public  Task<SuccessActivation> ActiveEmployee(int EmployeeId);
        public Task<IList<Request>> GetAllRequest();
        public Task<SuccessRequestClose> CloseRequest(int RequestId);

    }
}
