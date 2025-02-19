using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.ExamsScore.Commands.Models
{
    public class DeleteExamScoreCommand : IRequest<Response<string>>
    {
        public int ExamScoreID { get; set; }
    }
}
