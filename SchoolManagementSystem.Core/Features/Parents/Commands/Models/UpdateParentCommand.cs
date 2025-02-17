using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Parents.Commands.Models
{
    public class UpdateParentCommand : IRequest<Response<string>>
    {
        public int ParentID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
