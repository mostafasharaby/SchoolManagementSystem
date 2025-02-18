using SchoolManagementSystem.Core.Features.Departments.Queries.Models;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void DepartmentQueryMapping()
        {
            CreateMap<Department, GetAllDepartmentsQuery>();
            CreateMap<Department, GetDepartmentByIdQuery>();
        }
    }
}
