using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Fees.Queries.Models
{
    public class GetOutstandingFeesQuery : IRequest<Response<List<FeeDto>>>
    {
        public int StudentID { get; set; }
    }
}
