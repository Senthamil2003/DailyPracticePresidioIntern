﻿using System;
using System.Collections.Generic;

namespace SqlServerDatabaseApp.Model
{
    public partial class Area
    {
        public Area()
        {
            Employees = new HashSet<Employee>();
        }

        public string Area1 { get; set; } = null!;
        public string? Zipcode { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
