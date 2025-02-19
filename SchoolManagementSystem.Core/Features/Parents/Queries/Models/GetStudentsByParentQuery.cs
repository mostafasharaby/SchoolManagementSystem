using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Parents.Queries.Models
{
    public class GetStudentsByParentQuery : IRequest<Response<List<StudentDto>>>
    {
        public int ParentID { get; set; }
    }
}
