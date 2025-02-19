using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.Exams.Queries.Models
{
    public class GetExamByIdQuery : IRequest<Response<ExamDto>>
    {
        public int ExamID { get; set; }
    }
}
