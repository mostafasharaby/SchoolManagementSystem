using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Libraies.Commands.Models
{
    public class AddBookCommand : LibraryDto, IRequest<Response<string>>
    {
    }

}
