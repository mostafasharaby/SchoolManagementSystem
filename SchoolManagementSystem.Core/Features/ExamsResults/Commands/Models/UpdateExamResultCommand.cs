using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsResults.Commands.Models
{
    public class UpdateExamResultCommand : ExamResultDto, IRequest<Response<string>>
    {
        public int ExamResultID { get; set; }
    }
}
