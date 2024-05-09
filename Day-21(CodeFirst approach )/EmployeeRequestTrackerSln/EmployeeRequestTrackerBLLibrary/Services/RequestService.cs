﻿using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerBLLibrary.Services
{
    public interface RequestService
    {
        public Task<Request> CreateRequest(Request request);

        public Task<Request> CheckStatus(int id);


    }
}
