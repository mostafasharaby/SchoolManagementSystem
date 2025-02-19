using SchoolManagementSystem.Core.Features.ExamsResults.Commands.Models;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.ExamResultMapping
{
    public partial class ExamResultProfile
    {
        public void ExamResultCommandMapping()
        {
            CreateMap<AddExamResultCommand, ExamResult>();
            CreateMap<UpdateExamResultCommand, ExamResult>();
        }
    }
}
