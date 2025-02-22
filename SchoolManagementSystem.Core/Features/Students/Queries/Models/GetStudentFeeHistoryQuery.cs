using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentFeeHistoryQuery : IRequest<Response<List<FeeDto>>>
    {
        public string? StudentID { get; set; }
    }
}
