using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.StudentMapping
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            getStudentDtoQueryMapping();
            AddStudentProfile();
            UpdateStudentProfile();
        }
    }
}
