using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Departments.Commands.Models
{
    public class DeleteDepartmentCommand : IRequest<Response<string>>
    {
        public int DepartmentID { get; set; }
    }
}
