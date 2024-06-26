﻿using EmployeeRequestTrackerDALLibrary.Repository;
using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerDALLibrary.JoinedRepository
{
    public class RequestJoinedRepository:RequestRepository
    {
        public RequestJoinedRepository(RequestTrackerContext context) : base(context)
        {

        }
        public async override Task<List<Request>> GetAll()
        {
            await Console.Out.WriteLineAsync("insite db repo");
            return await _context.Requests.Include(r=>r.solutions)
                .Include(r=>r.RaisedByEmployee)
                .Include(r=>r.ClosedByEmployee)
                .ToListAsync();
        }
        public async override Task<Request> Get(int key)
        {
            Request Request = _context.Requests
                .Include(r => r.solutions)
                .ThenInclude(s=>s.AnsweredEmployee)
                .Include(r=> r.RaisedByEmployee)
                .Include(r => r.ClosedByEmployee)
                .FirstOrDefault(e => e.RequestNumber == key);
            if (Request != null)
            {
                return Request;
            }
            throw new NoDataFoundException("No Request avaliable for given Id");
        }
    }
}
