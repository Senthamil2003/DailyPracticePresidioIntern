using GovernmentRulesModelLibrary;

namespace CompanyTrackersln_Assignment_
{
    internal class CompanyManager
    {
        void GovernmentRulesViewer(IgovernmentRules employee)
        {
            Console.WriteLine(employee.LeaVeDetails());
            Console.WriteLine(employee.EmployeePF());
            if (employee.gratuityAmount() == -1)
            {
                Console.WriteLine("Not Applicable");
                return;
            }
            Console.WriteLine(employee.gratuityAmount());
        }
        void EmployeeManager()
        {
            Console.WriteLine("Enter Company");
            string company = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Id");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");
            string name=Console.ReadLine()??"";
            Console.WriteLine("Enter Designation");
            string designation = Console.ReadLine() ??"";
            Console.WriteLine("Enter Department");
            string department = Console.ReadLine() ??"";
            Console.WriteLine("Enter Name basic salary");
            double basicSalary=Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter experience");
            double experience = Convert.ToDouble(Console.ReadLine());
           
            if (company == "TCS")
            {
               TCS Tcsemployee = new TCS(employeeId, name, designation, department, basicSalary, experience);
                GovernmentRulesViewer(Tcsemployee);


            }
            else
            {
                Accenture Accentureemployee = new Accenture(employeeId, name, designation, department, basicSalary, experience);
                GovernmentRulesViewer(Accentureemployee);

            }
            



        }
        static void Main(string[] args)
        {
           CompanyManager companyManager = new CompanyManager();
            companyManager.EmployeeManager();
        }
    }
}
