using PizzaManagerAPI.Interface;
using PizzaManagerAPI.Model;
using PizzaManagerAPI.Model.DTO;
using System.Security.Cryptography;
using System.Text;

namespace PizzaManagerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IReposiroty<int, Customer> _userrepo;
        private readonly IReposiroty<int, UserCredential> _credentialrepo;
        private readonly ITokenService _tokenservices;

        public CustomerService(IReposiroty<int, Customer> userRepo, IReposiroty<int, UserCredential> credentialrepo,ITokenService tokenService)
        {
            _userrepo = userRepo;
            _credentialrepo = credentialrepo;
            _tokenservices= tokenService;
        }
        public async Task<bool> CheckPassword(byte[] pass1, byte[] pass2)
        {
            for (int i = 0; i < pass1.Length; i++)
            {
                if (pass1[i] != pass2[i])
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
                UserCredential user = await _credentialrepo.Get(loginDTO.Id);

                if (user == null)
                {
                    throw new Exception("Customer Name Password not correct");
                }
                HMACSHA512 hash = new HMACSHA512(user.HashedPassword);
                var password = hash.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
                if (await CheckPassword(password, user.Password))
                {
                     Customer customer= await _userrepo.Get(user.UserId);
                    SuccessLogin success = new SuccessLogin()
                    {
                        Code = 200,
                        Message = "User Successfully login",
                        Token = await _tokenservices.GenerateToken(customer)
                    };
                    return success;

                }
                throw new Exception("Customer Name Password not correct");
            }
            catch
            {
                throw;
            }

        }
        public async Task<UserCredential> CreateCredential(RegisterDTO dto)
        {

            HMACSHA512 hash = new HMACSHA512();

            UserCredential user = new UserCredential()
            {
               
                HashedPassword= hash.Key,
                Password = hash.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                UserName=dto.Email,
                
            };
            return  user;

        }
        public async Task<SuccessRegister> Register(RegisterDTO userDTO)
        {
            Customer customer = null;
            UserCredential user = null;
            try
            {
                customer = new Customer()
                {
                    Name = userDTO.Name,
                    Email = userDTO.Email,
                    Mobil = userDTO.Mobil, 
                };
                await  _userrepo.Add(customer);
                user = await CreateCredential(userDTO);
                user.UserId=customer.UserId;
                await _credentialrepo.Add(user);
                SuccessRegister success = new SuccessRegister()
                {
                    StatusCode = 200,
                    Message="Registered Successfully",
                    Customer=customer

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
