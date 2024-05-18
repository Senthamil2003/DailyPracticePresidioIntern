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
                if(await  CheckPassword(password, user.Password) && user.Status=="Enable")
                {
                    Employee employee= await _employeerepo.Get(user.EmployeeId);

                    SuccessLogin success = new SuccessLogin()
                    {
                        Code = 200,
                        Role = employee.Role,
                        Token = await _tokenservice.GenerateToken(employee)
                    };
                    return success;
                }
                throw new Exception("User Name Password not correct");
            }
            catch
            {
                throw;
            }
            
        }
        public async Task<User> CreateUser(EmployeeUserDTO dto)
        {

            HMACSHA512 hash = new HMACSHA512();
            
            User user = new User()
            {
                EmployeeId = dto.EmployeeId,
                PaswordHash =hash.Key,
                Password=hash.ComputeHash(Encoding.UTF8.GetBytes(dto.Password))
            };
            return user;

        }
        public async Task<SuccessLogin> Register(EmployeeUserDTO employeeDTO)
        {
            Employee employee = null;
            User user = null;
            try
            {
                employee=employeeDTO;
               await _employeerepo.Add(employee);
                employeeDTO.EmployeeId = employee.EmployeeId;
               user = await CreateUser(employeeDTO);
                await _userrepo.Add(user);

                SuccessLogin success = new SuccessLogin()
                {
                    Code = 200,
                    Role = employee.Role,
                    Token =await _tokenservice.GenerateToken(employeeDTO)
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
