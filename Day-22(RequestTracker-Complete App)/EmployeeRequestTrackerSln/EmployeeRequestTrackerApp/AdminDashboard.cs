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

     
        public async Task ViewAllRequest()
        {
            await Console.Out.WriteLineAsync("Total Request in View All");
            List<Request> requests= await _adminService.RequestList();
            

            foreach (Request request1 in requests)
            {
                if (request1.RequestRaisedBy != EmployeeId)
                {
                    await Console.Out.WriteLineAsync("------------------------------------------------");
                    await Console.Out.WriteLineAsync(request1.RequestNumber + " " + request1.RequestMessage);
                    await Console.Out.WriteLineAsync("------------------------------------------------");

                }
            }
            await Console.Out.WriteLineAsync("Enter the request number to view full status");
            int RequestNumber = Convert.ToInt32(Console.ReadLine());
            Request request = await _adminService.GetRequest(RequestNumber);
            await Console.Out.WriteLineAsync("------------------------------------------------");
            await Console.Out.WriteLineAsync("Request Number " + request.RequestNumber);
            await Console.Out.WriteLineAsync("Raised Request " + request.RequestMessage);
            await Console.Out.WriteLineAsync("Raised Date" + request.RequestDate);
            await Console.Out.WriteLineAsync("Closed Status " + request?.ClosedDate);
            await Console.Out.WriteLineAsync("Problem Status " + request?.ProblemStatus);
            await Console.Out.WriteLineAsync("Request status" + request?.RequestStatus);
            await Console.Out.WriteLineAsync("------------------------------------------------");
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
                    AnsweredEmployeeId = EmployeeId,
                    RaisedRequestId= RequestNumber,
                };
               await _adminService.AddSolution(solution);


            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
           

        }
        public async Task CloseRequest()
        {
            try
            {
                await Console.Out.WriteLineAsync("Solved equest");
                List<Request> requests = await _adminService.RequestList();

                foreach (Request request1 in requests)
                {
                    if (request1.ProblemStatus)
                    {
                        await Console.Out.WriteLineAsync("------------------------------------------------");
                        await Console.Out.WriteLineAsync(request1.RequestNumber + " " + request1.RequestMessage + "Problem Status");
                        await Console.Out.WriteLineAsync("------------------------------------------------");

                    }
                  
                }
                await Console.Out.WriteLineAsync("Enter the request number to close");
                int RequestNumber = Convert.ToInt32(Console.ReadLine());
                await _adminService.UpdateRequestStatus(RequestNumber);

            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
        public  async Task ViewFeedback()
        {
            try
            {
                await Console.Out.WriteLineAsync("Entier Feedback");
               List<Feedback> feedbacks=await _adminService.ViewFeedback(EmployeeId);
                foreach (Feedback feedback in feedbacks)
                {
                    await Console.Out.WriteLineAsync("Feedback Id  "+feedback.FeedbackId);
                    await Console.Out.WriteLineAsync(feedback.Solution.SolutionStatement);
                    await Console.Out.WriteLineAsync("Comment:  "+feedback.comment);
                    await Console.Out.WriteLineAsync("Rating:  "+feedback.Rating);
                    
                }

            }
            catch (Exception ex) {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
        void PrintOption()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("1.Raise Request\n2.RequestStatus\n3.View Solutino\n4.View All Request\n5.Give Solution\n6.Close Request\n7.View Feedback\n8.View own Request oOlutionspress\n9.Update Own Problem status\n10.Give Feedback\n 0 to exit");
            Console.WriteLine("-------------------------------------------------------------------");
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
                        await ViewSolution(); 
                        break;
                    case 4:
                        await ViewAllRequest();
                        break;
                    case 5:
                        await GiveSolution();
                        break;
                    case 6:
                        await CloseRequest();
                        break;
                    case 7:
                        await ViewFeedback();
                        break;
                    case 8:
                        await ViewSolution(); 
                        break;  
                    case 9:
                        await UpdateProblemStatus();
                        break;
                    case 10:
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
