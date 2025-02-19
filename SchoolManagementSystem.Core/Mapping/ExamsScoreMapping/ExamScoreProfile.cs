using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.ExamsScoreMapping
{
    public partial class ExamScoreProfile : Profile
    {
        public ExamScoreProfile()
        {
            ExamScoreCommandMapping();
            ExamScoreQueryMapping();
        }
    }
}
