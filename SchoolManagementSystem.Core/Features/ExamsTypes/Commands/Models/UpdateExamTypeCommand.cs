using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsTypes.Commands.Models
{
    public class UpdateExamTypeCommand : ExamTypeDto, IRequest<Response<string>>
    {
        public int ExamTypeID { get; set; }
    }
}
