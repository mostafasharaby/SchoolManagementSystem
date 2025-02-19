using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsTypes.Queries.Models
{
    public class GetAllExamTypesQuery : IRequest<Response<List<ExamTypeDto>>> { }
}
