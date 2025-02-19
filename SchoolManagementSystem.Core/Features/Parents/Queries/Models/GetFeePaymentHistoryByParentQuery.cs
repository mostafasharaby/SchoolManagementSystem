using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Parents.Queries.Models
{
    public class GetFeePaymentHistoryByParentQuery : IRequest<Response<List<FeeDto>>>
    {
        public int ParentID { get; set; }
    }
}
