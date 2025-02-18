using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            DepartmentsCommandMapping();
            DepartmentQueryMapping();
        }
    }
}
