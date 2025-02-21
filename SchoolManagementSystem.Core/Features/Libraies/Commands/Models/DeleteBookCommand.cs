using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Libraies.Commands.Models
{
    public class DeleteBookCommand : IRequest<Response<string>>
    {
        public int LibraryID { get; set; }
    }
}
