using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.Fees.Commands.Models
{
    public class DeleteFeeCommand : IRequest<Response<string>>
    {
        public int FeeID { get; set; }
    }
}
