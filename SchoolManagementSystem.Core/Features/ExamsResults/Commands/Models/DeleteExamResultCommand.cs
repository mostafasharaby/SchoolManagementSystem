using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.ExamsResults.Commands.Models
{
    public class DeleteExamResultCommand : IRequest<Response<string>>
    {
        public int ExamResultID { get; set; }
    }
}
