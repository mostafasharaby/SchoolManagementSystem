using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsScore.Queries.Models
{
    public class GetExamScoresByStudentQuery : IRequest<Response<List<ExamScoreDto>>>
    {
        public string StudentID { get; set; }
    }
}
