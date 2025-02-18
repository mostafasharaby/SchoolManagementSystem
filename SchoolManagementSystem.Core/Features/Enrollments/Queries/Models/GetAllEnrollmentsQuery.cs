using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Enrollments.Queries.Models
{
    public class GetAllEnrollmentsQuery : IRequest<Response<List<EnrollmentDto>>>
    {
    }

}
