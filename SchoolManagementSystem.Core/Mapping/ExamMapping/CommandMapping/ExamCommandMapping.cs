using SchoolManagementSystem.Core.Features.Exams.Commands.Models;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.ExamMapping
{
    public partial class ExamProfile
    {
        public void ExamCommandMapping()
        {
            CreateMap<AddExamCommand, Exam>();
            CreateMap<UpdateExamCommand, Exam>();

        }
    }
}
