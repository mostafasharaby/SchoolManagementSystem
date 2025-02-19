using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsScore.Queries.Models
{
    public class GetExamScoresQuery : IRequest<Response<List<ExamScoreDto>>> { }
}
