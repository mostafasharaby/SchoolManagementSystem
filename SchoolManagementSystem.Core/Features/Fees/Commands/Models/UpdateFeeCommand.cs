using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Fees.Commands.Models
{
    public class UpdateFeeCommand : FeeDto, IRequest<Response<string>>
    {
        public int FeeID { get; set; }
    }
}
