using EmployeeMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Repository
{
    public interface IEmployeeRepository
    {
        //viewEmployeeOffers()

        ///viewMostLikedOFfers()

        Employee ViewProfile(int Id);
    }
}
