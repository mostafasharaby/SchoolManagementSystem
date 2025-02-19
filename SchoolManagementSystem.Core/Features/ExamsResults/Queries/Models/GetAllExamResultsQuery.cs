using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsResults.Queries.Models
{
    public class GetAllExamResultsQuery : IRequest<Response<List<ExamResultDto>>>
    {
    }
}
