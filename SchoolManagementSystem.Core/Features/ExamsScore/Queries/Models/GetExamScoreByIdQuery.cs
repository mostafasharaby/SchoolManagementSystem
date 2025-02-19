using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsScore.Queries.Models
{
    public class GetExamScoreByIdQuery : IRequest<Response<ExamScoreDto>>
    {
        public int ExamScoreID { get; set; }
    }
}
