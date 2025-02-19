using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Fees.Commands.Models
{
    public class PayFeeCommand : FeeDto, IRequest<Response<string>>
    {
    }
}
