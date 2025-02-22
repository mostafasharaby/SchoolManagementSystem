using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetTeacherByIdQuery : IRequest<Response<TeacherDto>>
    {
        public string? TeacherID { get; set; }
    }
}
