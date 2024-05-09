using EmployeeRequestTrackerBLLibrary;
using EmployeeRequestTrackerBLLibrary.Services;
using RequestTrackerModelLibrary;

namespace EmployeeRequestTrackerApp
{
    public class Program
    {
        readonly EmployeeService _EmployeeBl;
        readonly RequestService _RequestService;    
        public Program()
        {
            _EmployeeBl = new EmployeeBl();
            _RequestService = new RequestBl();
        }
        public async Task Register()
        {
          
            await Console.Out.WriteLineAsync("Enter Name");
            string name=Console.ReadLine();
            await Console.Out.WriteLineAsync("Enter the role");
            string role = Console.ReadLine();
            await Console.Out.WriteLineAsync("Enter Password");
            string Password = Console.ReadLine();

            Employee employee = new Employee
            {
                Name = name,
                Role = role,
                Password = Password,

            };
            Employee result = await _EmployeeBl.Register(employee);
            await Console.Out.WriteLineAsync("Employee Added Succesfully"+result.Name+"  "+result.EmployeeId);

        }
        public async Task Login()
        {
            await Console.Out.WriteLineAsync("Enter Name");
            string name = Console.ReadLine();
            await Console.Out.WriteLineAsync("Enter the Password");
            string password = Console.ReadLine();
            if(await _EmployeeBl.Login(name, password))
            {
                await Console.Out.WriteLineAsync("Login successful");
            }
            else
            {
                await Console.Out.WriteLineAsync("Enter valid credentials");
            }
           
        }
        public async Task CreateRequest()
        {
            Request request = new Request()
            {
                RequestStatus="success",
                RequestClosedBy=1,
                RequestDate = DateTime.Now,
                RequestRaisedBy = 1,
                ClosedDate = DateTime.Now,
                RequestMessage = "Laptop problem",
               


            };
            var result= await _RequestService.CreateRequest(request);
         

        }
        public async Task CheckStatus()
        {
           Request result=await _RequestService.CheckStatus(2);
            await Console.Out.WriteLineAsync(result.RequestStatus);
        }
        static async Task Main(string[] args)
        {
        Program program = new Program();
            await program.Register();
            await program.Login();
            await program.CreateRequest();
            await program.CheckStatus();
            
        }
    }
}
