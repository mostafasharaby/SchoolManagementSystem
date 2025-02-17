using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Parents.Commands.Models
{
    public class DeleteParentCommand : IRequest<Response<string>>
    {
        public int ParentID { get; set; }
    }
}
