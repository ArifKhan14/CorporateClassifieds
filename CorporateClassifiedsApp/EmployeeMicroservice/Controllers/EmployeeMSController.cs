using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMicroservice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMSController : ControllerBase
    {
        private readonly IEmployeeRepository _empRepository;
        // GET: api/EmployeeMS
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EmployeeMS/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var emp = _empRepository.ViewProfile(id);
            return new OkObjectResult(emp);
        }

        // POST: api/EmployeeMS
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/EmployeeMS/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
