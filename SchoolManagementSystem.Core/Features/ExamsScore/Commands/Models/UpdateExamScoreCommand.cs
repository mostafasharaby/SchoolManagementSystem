using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsScore.Commands.Models
{
    public class UpdateExamScoreCommand : ExamScoreDto, IRequest<Response<string>>
    {
        public int ExamScoreID { get; set; }
    }
}
