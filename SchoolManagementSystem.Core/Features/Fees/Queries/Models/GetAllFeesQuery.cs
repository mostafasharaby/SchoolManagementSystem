using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Fees.Queries.Dto;

namespace SchoolManagementSystem.Core.Features.Fees.Queries.Models
{
    public class GetAllFeesQuery : IRequest<Response<List<FeeDto>>> { }
}
