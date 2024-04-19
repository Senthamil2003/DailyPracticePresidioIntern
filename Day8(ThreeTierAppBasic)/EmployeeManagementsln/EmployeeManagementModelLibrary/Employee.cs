using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementModelLibrary
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
     
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
