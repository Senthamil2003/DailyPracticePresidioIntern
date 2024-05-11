using EmployeeRequestTrackerBLLibrary.BusinessLogic;
using EmployeeRequestTrackerBLLibrary.Services;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerApp
{
    public  class UserDashboard
    {
        readonly UserService _userService;
        int EmployeeId;
        public UserDashboard(int id)
        {
             _userService = new UserBL();
             EmployeeId = id;
             
        }

        void PrintOption()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("1.Raise Request\n2.View Request Status\n3.Get All Account\npress 0 to exit");
            Console.WriteLine("-------------------------------------------------------------------");
        }
       public  async Task RaiseRequest()
        {
            await Console.Out.WriteLineAsync("Enter the Request Deatail");
            string requestStatement=Console.ReadLine()??"";
           
            Request request = new Request()
            {
                RequestMessage = requestStatement,
                RequestRaisedBy=EmployeeId   

            };
            await _userService.RaiseRequest(request);

        }
        public async Task RequestStatus()
        {
            await Console.Out.WriteLineAsync("Total Request status");
            List<Request> requests=await _userService.RaisedRequests(EmployeeId);
            foreach(Request request1 in requests)
            {
                await Console.Out.WriteLineAsync(request1.RequestNumber+" "+request1.RequestMessage);
            }
            await Console.Out.WriteLineAsync("Enter the request number to view full status");
            int RequestNumber = Convert.ToInt32(Console.ReadLine());
            Request request=await _userService.GetRequest(RequestNumber);
            await Console.Out.WriteLineAsync("Request Number "+request.RequestNumber);
            await Console.Out.WriteLineAsync("Raised Request " + request.RequestMessage);
            await Console.Out.WriteLineAsync("Raised Date" + request.RequestDate);
            await Console.Out.WriteLineAsync("Closed Status " + request?.ClosedDate);
            await Console.Out.WriteLineAsync("Problem Status " + request?.ProblemStatus);
            await Console.Out.WriteLineAsync("Request status" + request?.RequestStatus);
        }
        public async Task UserManager()
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
                       await RaiseRequest();
                        break;
                    case 2:
                        await RequestStatus();
                        break;
                    case 3:
                    
                        break;


                    default:
                        Console.WriteLine("Give valid");
                        break;


                }

            } while (option != 0);
        }
    }
}
