using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsResults.Queries.Models
{
    public class GetExamResultsByStudentQuery : IRequest<Response<List<ExamResultDto>>>
    {
        public string StudentID { get; set; }
    }

}
