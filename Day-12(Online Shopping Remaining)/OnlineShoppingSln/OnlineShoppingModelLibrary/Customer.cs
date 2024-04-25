using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingModelLibrary
{

    public class Customer
    {
        public int Id { get; set; }
        public string Phone { get; set; } = String.Empty;
        public int Age { get; set; }
        public string Name { get; set; }= String.Empty;
        public int CartId { get; set; }
        public Customer() { 
            Id = 0;
            Phone = String.Empty;
            Age = 0;
            Name = String.Empty;

        }
        public override string ToString()
        {
            return "Id : " + Id +
            "\nName : " + Name +
             "\nAge : " + Age;
        }

        public override bool Equals(object? obj)
        {
            return Name.Equals((obj as Customer).Name);
        }
    }
}
