using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Libraies.Queries.Models
{
    public class GetBookByIDCommand : IRequest<Response<LibraryDto>>
    {
        public int LibraryID { get; set; }
    }
}
