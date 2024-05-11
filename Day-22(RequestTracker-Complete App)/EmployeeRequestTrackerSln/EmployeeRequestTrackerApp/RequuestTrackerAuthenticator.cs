using EmployeeRequestTrackerBLLibrary;
using EmployeeRequestTrackerBLLibrary.BusinessLogic;
using EmployeeRequestTrackerBLLibrary.Services;
using RequestTrackerModelLibrary;

namespace EmployeeRequestTrackerApp
{
    public class RequuestTrackerAuthenticator
    {
        readonly AuthenticationService _authentication;
        public RequuestTrackerAuthenticator()
        {
            _authentication = new AuthenticationBL();
        
        }
        public async Task Login()
        {
            try
            {
              
                await Console.Out.WriteLineAsync("Enter your Name");
                string Name = Console.ReadLine() ?? "";
                await Console.Out.WriteLineAsync("Enter Password");
                string Password = Console.ReadLine() ?? "";
                (string result,int id)=await _authentication.Login(Name, Password);
                if (result == "User") {
                     UserDashboard user=new UserDashboard(id);
                   await user.UserManager();
                }
                else if(result =="Admin")
                {
                     AdminDashboard admin=new AdminDashboard(id);
                     await admin.AdminManager();
                     

                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }


        }
        public async Task Register()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter Name");
                string Name = Console.ReadLine() ?? "";
                await Console.Out.WriteLineAsync("Enter Your Role");
                string Role = Console.ReadLine() ?? "";
                await Console.Out.WriteLineAsync("Enter Password");
                string Password = Console.ReadLine() ?? "";



                Employee employee = new Employee()
                {
                    Name = Name,
                    Role = Role,
                    Password = Password
                };
                await _authentication.Register(employee);
                await Console.Out.WriteLineAsync(employee.EmployeeId+"Registered Successfully");
            }
            catch (Exception ex) {
                await Console.Out.WriteLineAsync(ex.Message);
            }
         
           
            
        }
        void PrintOption()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("1.Login\n2.Signup\n3.Get All Account\nAny Key to exit");
            Console.WriteLine("-------------------------------------------------------------------");
        }
       public async Task RequestTracker()
        {
            int option;
            do
            {
                PrintOption();
                Console.WriteLine("Enter the Option");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        await Login();
                        break;
                    case 2:
                        await Register();
                        break;
                    case 3:
                      
                        break;


                    default:
                        Console.WriteLine("Give valid");
                        break;

                }

            } while (option != 0);
        }

        static async Task Main(string[] args)
        {
        RequuestTrackerAuthenticator requestTrackermanager = new RequuestTrackerAuthenticator();
        await requestTrackermanager.RequestTracker();
       
            
        }
    }
}
