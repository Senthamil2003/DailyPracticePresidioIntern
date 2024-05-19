using EmployeeManagerApi.CustomExceptions;
using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;
using EmployeeManagerApi.Model.DTO;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeManagerApi.BusinessLogic
{
    public class AuthenticationService:IAuthenticationService
    {
        private readonly IReposiroty<int, Employee> _employeerepo;
        private readonly IReposiroty<int, User> _userrepo;
        private readonly ITokenService _tokenservice;

        public AuthenticationService(IReposiroty<int,Employee> employeeRepo,IReposiroty<int ,User> userrepo,ITokenService tokenservice) {
            _employeerepo=employeeRepo;
            _userrepo = userrepo;
            _tokenservice=tokenservice;
        }
        public async  Task<bool> CheckPassword(byte[] pass1, byte[] pass2)
        {
            for(int i=0;i<pass1.Length;i++)
            {
                if (pass1[i]!= pass2[i])
                {
                    return false;
                    
                }
            }
            return true;
        }
        public async Task<SuccessLogin> Login(LoginDTO loginDTO)
        {
            try
            {
                User user = await _userrepo.Get(loginDTO.Id);
                if (user == null)
                {
                    throw new Exception("User Name Password not correct");
                }
                HMACSHA512 hash = new HMACSHA512(user.PaswordHash);
                var password = hash.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
                if(await  CheckPassword(password, user.Password) )
                {
                    if(user.Status == "Enable")
                    {
                        Employee employee = await _employeerepo.Get(user.EmployeeId);

                        SuccessLogin success = new SuccessLogin()
                        {
                            Code = 200,
                            Role = employee.Role,
                            Token = await _tokenservice.GenerateToken(employee)
                        };
                        return success;
                    }
                    throw new UserNotVerifiedException();
 
                }
                throw new Exception("User Name Password not correct");
            }
            catch
            {
                throw;
            }
            
        }
        public async Task<User> CreateUser(int id,string password)
        {

            HMACSHA512 hash = new HMACSHA512();
            
            User user = new User()
            {
                PaswordHash =hash.Key,
                Password=hash.ComputeHash(Encoding.UTF8.GetBytes(password))
            };
            return user;

        }
        public async Task<SuccessRegisterDTO> Register(EmployeeUserDTO employeeDTO)
        {
            Employee employee = null;
            User user = null;
            try
            {
                employee = new Employee()
                {
                    Name=employeeDTO.Name,
                    Phone=employeeDTO.Phone,
                    Image=employeeDTO.Image,
                    Role = employeeDTO.Role
                };
               await _employeerepo.Add(employee);
               user = await CreateUser(employee.EmployeeId,employeeDTO.Password);
                user.EmployeeId=employee.EmployeeId;
                await _userrepo.Add(user);

                SuccessRegisterDTO success = new SuccessRegisterDTO()
                {
                    Code=200,
                    Message="User Registered Successsfully",
                    EmployeeId=employee.EmployeeId
                };

               return success;

            }
            catch
            {
                throw;
            }

        }
      
    }
}
