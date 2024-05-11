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
    public class AdminDashboard:UserDashboard
    {
        readonly AdminService _adminService;
        int EmployeeId;
        public AdminDashboard(int id):base(id) {
            _adminService = new AdminBL();
            EmployeeId = id;
        }

        void PrintOption()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("1.Raise Request\n2.Signup\n3.View All Request\n4.Give Solution\npress 0 to exit");
            Console.WriteLine("-------------------------------------------------------------------");
        }
        public async Task ViewAllRequest()
        {
            await Console.Out.WriteLineAsync("Total Request");
            List<Request> requests= await _adminService.RequestList();
            foreach (Request request1 in requests)
            {
                await Console.Out.WriteLineAsync(request1.RequestNumber+" "+request1.RequestMessage);
            }
            await Console.Out.WriteLineAsync("Enter the request number to view full status");
            int RequestNumber = Convert.ToInt32(Console.ReadLine());
            Request request = await _adminService.GetRequest(RequestNumber);
            await Console.Out.WriteLineAsync("Request Number " + request.RequestNumber);
            await Console.Out.WriteLineAsync("Raised Request " + request.RequestMessage);
            await Console.Out.WriteLineAsync("Raised Date" + request.RequestDate);
            await Console.Out.WriteLineAsync("Closed Status " + request?.ClosedDate);
            await Console.Out.WriteLineAsync("Problem Status " + request?.ProblemStatus);
            await Console.Out.WriteLineAsync("Request status" + request?.RequestStatus);
        }
        public async Task GiveSolution()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter the Request id to give solution");
                int RequestNumber = Convert.ToInt32(Console.ReadLine());
                Request request = await _adminService.GetRequest(RequestNumber);
                await Console.Out.WriteLineAsync("Request Number " + request.RequestNumber);
                await Console.Out.WriteLineAsync("Raised Request " + request.RequestMessage);
                await Console.Out.WriteLineAsync("Raised Date" + request.RequestDate);
                await Console.Out.WriteLineAsync("Closed Status " + request?.ClosedDate);
                await Console.Out.WriteLineAsync("Problem Status " + request?.ProblemStatus);
                await Console.Out.WriteLineAsync("Request status" + request?.RequestStatus);
                await Console.Out.WriteLineAsync("Enter the solution");
                string solutionStatement =Console.ReadLine()??"";
                Solution solution = new Solution()
                {
                    SolutionStatement = solutionStatement,
                    AnsweredEmployeeId = EmployeeId
                };
                _adminService.GivenSolutions(solution);


            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
           

        }
        public async Task AdminManager()
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
                        await ViewAllRequest();
                        break;


                    default:
                        Console.WriteLine("Give valid");
                        break;


                }

            } while (option != 0);
        }

    }
}
