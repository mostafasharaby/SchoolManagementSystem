using SchoolManagementSystem.Core.Features.ExamsTypes.Commands.Models;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.ExamsTypeMapping
{
    public partial class ExamTypeProfile
    {
        public void ExamTypeCommandMapping()
        {
            CreateMap<AddExamTypeCommand, ExamType>();
            CreateMap<UpdateExamTypeCommand, ExamType>();
        }
    }
}

