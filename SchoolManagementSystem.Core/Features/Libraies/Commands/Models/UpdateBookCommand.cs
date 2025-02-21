using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Libraies.Commands.Models
{
    public class UpdateBookCommand : LibraryDto, IRequest<Response<string>>
    {
        public int LibraryID { get; set; }
    }
}
