using CrudApi.Data;
using CrudApi.Dto.Department;
using CrudApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplecationDbContext context;

        public DepartmentsController(ApplecationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            var department = context.Departments.Select(x => new GetDepDto
            {
                Id = x.Id,
                Name = x.Name
            });


            return Ok(department);

        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var department = context.Departments.Find(id);


            if (department == null)
            {
                return NotFound("the department is not found");
            }

            GetDepDto dep = new GetDepDto
            {
                Id = department.Id,
                Name = department.Name

            };


            return Ok(dep);

        }

        [HttpPost("Create")]
        public IActionResult Create(CreateDep dep)
        {
            var department = new Department
            {
                Name = dep.Name
            };

            context.Departments.Add(department);
            context.SaveChanges();
            return Ok(dep);

        }


        [HttpPut("Update")]
        public IActionResult Update(CreateDep dep, int id)
        {

            var department = context.Departments.Find(id);
            if (department == null)
            {
                return NotFound("the department is not found");
            }

            


            department.Name = dep.Name;
          
            context.SaveChanges();
            return Ok(dep);

        }


        [HttpDelete("Delete")]
        public IActionResult Remove(int id)
        {

            var department = context.Departments.Find(id);
            if (department == null)
            {
                return NotFound("the department is not found");
            }
            CreateDep dep = new CreateDep()
            {
                Name= department.Name
            };
            context.Departments.Remove(department);
            context.SaveChanges();
            return Ok(dep);

        }


    }
}
