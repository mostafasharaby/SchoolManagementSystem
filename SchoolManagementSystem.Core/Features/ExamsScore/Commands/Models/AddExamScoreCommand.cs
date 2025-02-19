using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsScore.Commands.Models
{
    public class AddExamScoreCommand : ExamScoreDto, IRequest<Response<string>>
    {
    }
}
