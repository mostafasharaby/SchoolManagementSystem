using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsTypes.Queries.Models
{
    public class GetExamTypeByIdQuery : IRequest<Response<ExamTypeDto>>
    {
        public int ExamTypeID { get; set; }
    }
}
