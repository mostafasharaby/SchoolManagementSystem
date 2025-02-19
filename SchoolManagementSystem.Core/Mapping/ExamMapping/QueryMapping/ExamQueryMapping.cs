using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.ExamMapping
{
    public partial class ExamProfile
    {
        public void ExamQueryMapping()
        {
            CreateMap<Exam, ExamDto>();
        }
    }
}
