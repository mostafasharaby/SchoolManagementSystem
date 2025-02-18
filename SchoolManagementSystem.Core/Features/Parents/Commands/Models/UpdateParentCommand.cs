using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Parents.Commands.Models
{
    public class UpdateParentCommand : ParentDto, IRequest<Response<string>>
    {
        public int ParentID { get; set; }
    }
}
