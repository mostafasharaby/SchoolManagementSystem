using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Exams.Commands.Models
{
    public class AddExamCommand : ExamDto, IRequest<Response<string>>
    {
    }
}
