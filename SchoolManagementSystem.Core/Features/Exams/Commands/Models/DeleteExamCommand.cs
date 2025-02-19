using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Exams.Commands.Models
{
    public class DeleteExamCommand : IRequest<Response<string>>
    {
        public int ExamID { get; set; }
    }
}
