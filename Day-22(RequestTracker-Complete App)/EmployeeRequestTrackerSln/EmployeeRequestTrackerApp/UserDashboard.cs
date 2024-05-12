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
            Console.WriteLine("1.Raise Request\n2.View Request Status\n3.View Solution\n4.Update ProblemStatus\npress 0 to exit");
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
                await Console.Out.WriteLineAsync("------------------------------------------------");
                await Console.Out.WriteLineAsync(request1.RequestNumber+" "+request1.RequestMessage);
                await Console.Out.WriteLineAsync("------------------------------------------------");
            }
            await Console.Out.WriteLineAsync("Enter the request number to view full status");
            int RequestNumber = Convert.ToInt32(Console.ReadLine());
            Request request=await _userService.GetRequest(RequestNumber);
            await Console.Out.WriteLineAsync("------------------------------------------------");
            await Console.Out.WriteLineAsync("Request Number "+request.RequestNumber);
            await Console.Out.WriteLineAsync("Raised Request " + request.RequestMessage);
            await Console.Out.WriteLineAsync("Raised Date" + request.RequestDate);
            await Console.Out.WriteLineAsync("Closed Status " + request?.ClosedDate);
            await Console.Out.WriteLineAsync("Closed Status " + request?.ClosedByEmployee?.Name);
            await Console.Out.WriteLineAsync("Problem Status " + request?.ProblemStatus);
            await Console.Out.WriteLineAsync("Request status" + request?.RequestStatus);
            await Console.Out.WriteLineAsync("------------------------------------------------");
        }
        public async Task ViewSolution()
        {
            await Console.Out.WriteLineAsync("Enter the Request Number");
            int RequestNumber = Convert.ToInt32(Console.ReadLine());
            List<Solution> solutions = await _userService.ViewSolution(RequestNumber);
            foreach (Solution solution in solutions)
            {
                await Console.Out.WriteLineAsync("------------------------------------------------");
                await Console.Out.WriteLineAsync("Solution Id" + solution.SolutionId);
                await Console.Out.WriteLineAsync("Solution: " + solution.SolutionStatement);
                await Console.Out.WriteLineAsync("Given Name" + solution.AnsweredEmployee.Name);
                await Console.Out.WriteLineAsync("Posted Date" + solution.PostedDate);
                await Console.Out.WriteLineAsync("------------------------------------------------");
            }

        }
        public async Task UpdateProblemStatus()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter the Request Number");
                int RequestNumber = Convert.ToInt32(Console.ReadLine());
                List<Solution> solutions = await _userService.ViewSolution(RequestNumber);
                foreach (Solution solution in solutions)
                {
                    await Console.Out.WriteLineAsync("------------------------------------------------");
                    await Console.Out.WriteLineAsync("Solution Id " + solution.SolutionId);
                    await Console.Out.WriteLineAsync("Solution: " + solution.SolutionStatement);
                    await Console.Out.WriteLineAsync("Solution Given by " + solution.AnsweredEmployee.EmployeeId);
                    await Console.Out.WriteLineAsync("Posted Date " + solution.PostedDate);
                    await Console.Out.WriteLineAsync("------------------------------------------------");
                }
                await Console.Out.WriteLineAsync("Enter the Solution Id");
                int SolutionId = Convert.ToInt32(Console.ReadLine());
                await Console.Out.WriteLineAsync("Enter the comment for solution");
                string comment = Console.ReadLine() ?? "";
                await _userService.UpdateProblemStatus(SolutionId, RequestNumber, comment);

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }


        }
        public async Task GiveFeedback()
        {
            try
            {
                await Console.Out.WriteLineAsync("Enter the Request Number");
                int RequestNumber = Convert.ToInt32(Console.ReadLine());
                List<Solution> solutions = await _userService.ViewSolution(RequestNumber);
                foreach (Solution solution in solutions)
                {
                    await Console.Out.WriteLineAsync("------------------------------------------------");
                    await Console.Out.WriteLineAsync("Solution Id" + solution.SolutionId);
                    await Console.Out.WriteLineAsync("Solution: " + solution.SolutionStatement);
                    await Console.Out.WriteLineAsync("Given Name" + solution.AnsweredEmployee.Name);
                    await Console.Out.WriteLineAsync("Posted Date" + solution.PostedDate);
                    await Console.Out.WriteLineAsync("------------------------------------------------");
                }

                await Console.Out.WriteLineAsync("Enter the Solution id to give Feedback");
                int solutionId = Convert.ToInt32(Console.ReadLine());
                Solution NeededSolution= await _userService.GetSolution(solutionId);
                int id = NeededSolution.AnsweredEmployeeId;
                await Console.Out.WriteLineAsync("Enter feedback");
                string comment = Console.ReadLine() ??"";
                await Console.Out.WriteLineAsync("Enter the rating of 1-5");
                int rating= Convert.ToInt32(Console.ReadLine());
                Feedback feedback = new Feedback()
                {
                    EmployeeId= id,
                    comment = comment,
                    SolutionId = solutionId,
                    Rating = rating

                };
               await _userService.AddFeedback(feedback);
            }
            catch(Exception ex) 
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
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
                        await ViewSolution();
                        break;
                    case 4:
                        await UpdateProblemStatus();
                        break;
                    case 5:
                        await GiveFeedback();
                        break;
                    default:
                        Console.WriteLine("Give valid");
                        break;

                }

            } while (option != 0);
        }
    }
}
