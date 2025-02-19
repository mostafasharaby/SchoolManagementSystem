using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Exams.Queries.Models
{
    public class GetAllExamsQuery : IRequest<Response<List<ExamDto>>> { }
}
