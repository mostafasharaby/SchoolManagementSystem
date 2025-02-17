using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Core.Features.Fees.Queries.Dto;

namespace SchoolManagementSystem.Core.Features.Fees.Queries.Models
{
    public class GetFeeByIdQuery : IRequest<Response<FeeDto>>
    {
        public int FeeID { get; set; }
    }
}
