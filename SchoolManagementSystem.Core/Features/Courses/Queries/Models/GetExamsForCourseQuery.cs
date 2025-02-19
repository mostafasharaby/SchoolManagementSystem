using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Courses.Queries.Models
{
    public class GetExamsForCourseQuery : IRequest<Response<List<ExamDto>>>
    {
        public int CourseID { get; set; }
    }
}
