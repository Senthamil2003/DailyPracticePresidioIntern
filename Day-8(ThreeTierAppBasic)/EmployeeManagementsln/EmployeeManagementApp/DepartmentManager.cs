using EmployeeManagementBLLibrary;
using EmployeeManagementBLLibrary.CustomExceptionHandler;
using EmployeeManagementModelLibrary;
namespace EmployeeManagementApp
{
    internal class DepartmentManager
    {
        DepartmentBL departmentBL = new DepartmentBL();
        void AddDepartment()
        {

            
            try
            {
                Console.WriteLine("Pleae enter the department name");
                string name = Console.ReadLine()??"";
                Console.WriteLine("Pleae enter the department Head Id");
                int Headid = Convert.ToInt32(Console.ReadLine());

                Department department = new Department() { Name = name, Department_Head_Id=Headid};
                int id = departmentBL.AddDepartment(department);
                Console.WriteLine("Congrats. We ahve created the department for you and the Id is " + id);
                Console.WriteLine("Pleae enter the department name");
                name = Console.ReadLine()??"";
                Console.WriteLine("Pleae enter the department Head Id");
                Headid = Convert.ToInt32(Console.ReadLine());
                department = new Department() { Name = name,Department_Head_Id=Headid};
                id = departmentBL.AddDepartment(department);
                Console.WriteLine("Congrats. We ahve created the department for you and the Id is " + id);
            }
            catch (DuplicateDepartmentNameException ddne)
            {
                Console.WriteLine(ddne.Message);
            }
        }
        void RetriveAllDepartment()
        {
            try
            {
                Console.WriteLine("Retrive All");
                List<Department> data = departmentBL.GetDepartmentList();
                Console.WriteLine(data.Count);
                foreach (Department department in data)
                {
                    Console.WriteLine( department.ToString());
                }

            }
            catch(NullDepartmentValueException e) {
                Console.WriteLine(e.Message);
            }

        }
        void RetriveById()
        {
            try
            {
                Console.WriteLine("Enter the id for the department");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(departmentBL.GetDepartmentById(id).ToString());
            }
            catch (NullDepartmentValueException e)
            {
                Console.WriteLine(e.Message);
            }


        }
        void RetriveHeadIdById()
        {
            try
            {
                Console.WriteLine("Enter the id for the department");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(departmentBL.GetDepartmentHeadId(id).ToString());
                
            }
            catch (NullDepartmentValueException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        void RetriveByName()
        {
            try
            {
                Console.WriteLine("Enter Name");
                string name = Console.ReadLine() ?? "";
                Console.WriteLine(departmentBL.GetDepartmentByName(name).ToString());
            }
            catch (NullDepartmentValueException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        void UpdateDepartment()
        {
            try
            {
                Console.WriteLine("Enter Name");
                string OldName = Console.ReadLine() ?? "";
                Console.WriteLine("Enter Name");
                string NewName = Console.ReadLine() ?? "";
                departmentBL.ChangeDepartmentName(OldName, NewName);
                Console.WriteLine(departmentBL.GetDepartmentByName(NewName).ToString());
            }
            catch (NullDepartmentValueException e)
            {
                Console.WriteLine(e.Message);
            }


        }
        static void Main(string[] args)
        {
            DepartmentManager app = new DepartmentManager();
            app.AddDepartment();
            app.RetriveAllDepartment();
            app.RetriveById();
            app.RetriveByName();
            app.UpdateDepartment();
            app.RetriveHeadIdById();
            
        }
    }
}
