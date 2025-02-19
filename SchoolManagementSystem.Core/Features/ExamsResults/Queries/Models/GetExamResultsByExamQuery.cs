using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsResults.Queries.Models
{
    public class GetExamResultsByExamQuery : IRequest<Response<List<ExamResultDto>>>
    {
        public int ExamID { get; set; }
    }
}
