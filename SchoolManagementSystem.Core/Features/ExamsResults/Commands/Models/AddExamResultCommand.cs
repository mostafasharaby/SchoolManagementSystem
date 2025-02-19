using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsResults.Commands.Models
{
    public class AddExamResultCommand : ExamResultDto, IRequest<Response<string>>
    {
    }
}
