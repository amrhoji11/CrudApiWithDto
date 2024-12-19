using System.Runtime.CompilerServices;

namespace CrudApi.Dto.Employee
{
    public class CreateEmpDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int DepartmentId { get; set; }
    }
}
