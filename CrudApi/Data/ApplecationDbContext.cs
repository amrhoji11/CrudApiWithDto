using CrudApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Data
{
    public class ApplecationDbContext:DbContext
    {

        public ApplecationDbContext(DbContextOptions<ApplecationDbContext>options):base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
