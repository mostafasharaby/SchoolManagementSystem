using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsScore.Queries.Models
{
    public class GetExamScoresByExamQuery : IRequest<Response<List<ExamScoreDto>>>
    {
        public int ExamID { get; set; }
    }
}
