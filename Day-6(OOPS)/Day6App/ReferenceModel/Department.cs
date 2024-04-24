﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceModel
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public int Department_Head { get; set; }
        public override bool Equals(object? obj)
        {
        
            return this.Name.Equals((obj as Department).Name);
        }
        public override string ToString()
        {
            return Id + " " + Name + " " + Department_Head;
        }

    }
}
