using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsResults.Queries.Models
{
    public class GetExamResultByIdQuery : IRequest<Response<ExamResultDto>>
    {
        public int ExamResultID { get; set; }
    }

}
