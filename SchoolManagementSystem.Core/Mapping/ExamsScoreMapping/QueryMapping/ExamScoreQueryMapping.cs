using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.ExamsScoreMapping
{
    public partial class ExamScoreProfile
    {
        public void ExamScoreQueryMapping()
        {
            CreateMap<ExamScore, ExamScoreDto>();

        }
    }
}
