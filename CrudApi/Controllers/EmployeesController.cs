using CrudApi.Data;
using CrudApi.Dto.Employee;
using CrudApi.Model;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplecationDbContext context;

        public EmployeesController(ApplecationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var employee = context.Employees.ToList();
            var emp = employee.Adapt<IEnumerable<GetEmpDto>>();
            return Ok(emp);

        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null) 
            {
                return NotFound("the employee is not found");
            }

            var emp = employee.Adapt<GetEmpDto>();
            return Ok(emp);

        }

        [HttpPost("Create")]
        public IActionResult Create(CreateEmpDto emp)
        {
            var employee = emp.Adapt<Employee>();
         context.Employees.Add(employee);
            context.SaveChanges();
            return Ok(emp);

        }


        [HttpPut("Update")]
        public IActionResult Update(CreateEmpDto emp,int id)
        {

            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound("the employee is not found");
            }
           emp.Adapt(employee);
            context.SaveChanges();
            return Ok(emp);

        }


        [HttpDelete("Delete")]
        public IActionResult Remove(int id)
        {

            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound("the employee is not found");
            }
            var emp=employee.Adapt<CreateEmpDto>();
           
            context.Employees.Remove(employee);
            context.SaveChanges();
            return Ok(emp);

        }




    }
}
