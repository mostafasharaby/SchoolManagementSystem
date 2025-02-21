using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentExamResultsQuery : IRequest<Response<List<ExamResultDto>>>
    {
        public int StudentID { get; set; }
    }
}
