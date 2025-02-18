using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Enrollments.Queries.Models
{
    public class GetEnrollmentByIdQuery : IRequest<Response<EnrollmentDto>>
    {
        public int EnrollmentID { get; set; }
    }

}
