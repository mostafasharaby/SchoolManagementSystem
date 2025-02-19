using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Exams.Commands.Models
{
    public class UpdateExamCommand : ExamDto, IRequest<Response<string>>
    {
        public int ExamID { get; set; }
    }
}
