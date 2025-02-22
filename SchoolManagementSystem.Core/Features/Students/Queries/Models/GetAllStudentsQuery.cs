using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;
namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetAllStudentsQuery : IRequest<Response<List<Student_Teacher_ClassRomm_Parent_Dto>>>
    {
    }
}
