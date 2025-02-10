using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.ApplicationUser.Commands.Models
{
    public class DeleteAppUserCommand : IRequest<Response<string>>
    {
        public string? Id { get; set; }
    }
}
