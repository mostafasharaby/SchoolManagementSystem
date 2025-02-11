using MediatR;
using SchoolManagementSystem.Core.Features.ApplicationUser.Queries.Results;
using SchoolManagementSystem.Core.Wrapper;

namespace SchoolManagementSystem.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUsersDtoCommand : IRequest<PaginatedResult<AppUserDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
