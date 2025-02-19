using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Exams.Queries.Models
{
    public class GetExamsByCourseQuery : IRequest<Response<List<ExamDto>>>
    {
        public int CourseID { get; set; }
    }
}
