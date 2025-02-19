using SchoolManagementSystem.Core.Features.ExamsScore.Commands.Models;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.ExamsScoreMapping
{
    public partial class ExamScoreProfile
    {
        public void ExamScoreCommandMapping()
        {
            CreateMap<AddExamScoreCommand, ExamScore>();
            CreateMap<UpdateExamScoreCommand, ExamScore>();
        }
    }
}

