using EmployeeMicroservice.DBContext;
using EmployeeMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _dbContext;

        public EmployeeRepository(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Employee ViewProfile(int id)
        {
            return _dbContext.Employees.Find(id);
        }
    }
}
