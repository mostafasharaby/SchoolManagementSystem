using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.ExamsTypeMapping
{
    public partial class ExamTypeProfile
    {
        public void ExamTypeQueryMapping()
        {
            CreateMap<ExamType, ExamTypeDto>();

        }
    }
}
