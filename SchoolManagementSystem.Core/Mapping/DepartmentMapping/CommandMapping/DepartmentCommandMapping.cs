using SchoolManagementSystem.Core.Features.Departments.Commands.Models;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void DepartmentsCommandMapping()
        {
            CreateMap<AddDepartmentCommand, Department>();
            CreateMap<UpdateDepartmentCommand, Department>();
        }
    }
}
