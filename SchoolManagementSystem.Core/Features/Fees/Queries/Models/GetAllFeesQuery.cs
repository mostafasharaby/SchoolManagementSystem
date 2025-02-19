using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Fees.Queries.Models
{
    public class GetAllFeesQuery : IRequest<Response<List<FeeDto>>> { }
}
