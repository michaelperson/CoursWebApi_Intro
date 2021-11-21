using FirstWebApi.Infra;
using FirstWebApi.Interfaces;
using FirstWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IContext CTX;
        public EmployeesController(IContext ctx)
        {
            CTX = ctx;
        }

        [HttpGet()]
        /// <summary>
        /// GET api/Employees
        /// </summary>
        /// <returns>return a <see cref="IEnumerable{Employee}<"/></returns>
        public IEnumerable<Employee> Get()
        {
            return CTX.Employees;
        }

        [HttpGet("async")]
        /// <summary>
        /// GET api/Employees
        /// </summary>
        /// <returns>return a <see cref="IEnumerable{Employee}<"/></returns>
        public IAsyncEnumerable<Employee> GetAsync()
        {
            return CTX.Employees.ToAsyncEnumerable<Employee>();
        }

        [HttpGet("IActionEmployee")]
        /// <summary>
        /// GET api/Employees
        /// </summary>
        /// <returns>return a <see cref="IEnumerable{Employee}<"/></returns>
        public IActionResult GetEmps()
        {
            return new OkObjectResult(CTX.Employees);
        }



        [HttpGet("ActionGet/{id:MyConstraint}")] 
        public ActionResult<Employee> GetIAction(int id)
        {
            
            Employee e = CTX.Employees.SingleOrDefault(e => e.Id.Equals(id));
            if (e != null)
                return e;
            else
                return NotFound(id); 
        }



        [HttpGet("{id:MyConstraint}")]
        /// <summary>
        /// GET api/Employees/{id:int:range(1,50)}
        /// </summary>
        /// <param name="id">The Employee id</param>
        /// <returns>return a <see cref="Employee<"/> with the parameter value as Id</returns>
        public Employee Get(int id)
        {
            return CTX.Employees.SingleOrDefault(e=>e.Id.Equals(id));
        }

        [HttpPost]
        /// <summary>
        /// POST api/Employees
        /// </summary>
        /// <param name="employee">The <see cref="Employee"/> to add</param>
        public void Post(Employee employee)
        {
            int maxId = CTX.Employees.Max(m => m.Id);
            employee.Id = maxId;
            CTX.Employees.Add(employee);
        }

        [HttpPut]
        /// <summary>
        /// PUT api/Employees
        /// </summary>
        /// <param name="employee">The <see cref="Employee"/> to update</param>
        public void Put(int id, Employee employee)
        {
            int idxEmployee =  CTX.Employees.FindIndex(m => m.Id.Equals(id));
            
            CTX.Employees[idxEmployee]=employee;
        }

        [HttpDelete]
        /// <summary>
        /// DELETE api/Employees/{id}
        /// </summary>
        /// <param name="id">The Employee id</param> 
        public void Delete(int id)
        {
            CTX.Employees.Remove(CTX.Employees.SingleOrDefault(e => e.Id.Equals(id)));
        }


    }
}
