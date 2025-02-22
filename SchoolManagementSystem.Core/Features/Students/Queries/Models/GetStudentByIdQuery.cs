using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<StudentDto>>
    {
        public string? StudentID { get; set; }
    }
}
