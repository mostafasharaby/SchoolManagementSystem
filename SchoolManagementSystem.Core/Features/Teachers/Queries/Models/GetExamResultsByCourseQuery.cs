using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetExamResultsByCourseQuery : IRequest<Response<List<ExamResultDto>>>
    {
        public int TeacherID { get; set; }
        public int CourseID { get; set; }
    }
}
