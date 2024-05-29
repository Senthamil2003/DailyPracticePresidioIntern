using EmployeeManagerApi.BusinessLogic;
using EmployeeManagerApi.Context;
using EmployeeManagerApi.Interface;
using EmployeeManagerApi.Model;
using EmployeeManagerApi.Model.DTO;
using EmployeeManagerApi.Reepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagerTester
{
    public  class EmployeeTest
    { 
        EmployeeContext context;
        IReposiroty<int, Employee> employeeRepo;
        IReposiroty<int ,Request> requestRepo;
        IUserService userService;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("SampleDb");
            context = new EmployeeContext(optionBuilder.Options);
            employeeRepo = new EmployeeRepository(context); 
            requestRepo = new RequestRepository(context);
            userService = new UserService(employeeRepo,requestRepo);

        }
        [Test]
        public void RaiseRequest()
        {
            RaiseRequestDTO raiseRequest = new RaiseRequestDTO()
            {
                EmployeeId = 1,
                Problem = "Nothig to speciy"
            };
            userService.RaiseRequest( raiseRequest );

        }
    }
}
