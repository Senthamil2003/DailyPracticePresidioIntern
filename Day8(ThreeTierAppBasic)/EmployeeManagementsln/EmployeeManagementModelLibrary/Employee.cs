using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementModelLibrary
{
    public class Employee
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public Employee(int id,string name)
        {
            Id = id;
            Name = name;

        }
        public Employee() { 
        }
        public override bool Equals(object? obj)
        {

            return this.Name.Equals((obj as Employee).Name);
        }
        public override string ToString()
        {
            return Id + " " + Name ;
        }
    }
}
