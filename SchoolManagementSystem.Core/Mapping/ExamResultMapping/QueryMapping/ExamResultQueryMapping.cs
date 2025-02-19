using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.ExamResultMapping
{
    public partial class ExamResultProfile
    {
        public void ExamResultQueryMapping()
        {
            CreateMap<ExamResult, ExamResultDto>();
        }
    }
}
