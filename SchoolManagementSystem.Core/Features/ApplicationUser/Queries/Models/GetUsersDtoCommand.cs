using MediatR;
using SchoolManagementSystem.Core.Wrapper;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUsersDtoCommand : IRequest<PaginatedResult<AppUserDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
