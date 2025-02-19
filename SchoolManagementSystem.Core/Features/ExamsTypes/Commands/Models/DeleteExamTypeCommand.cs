using MediatR;
using SchoolManagementSystem.Core.Bases;

namespace SchoolManagementSystem.Core.Features.ExamsTypes.Commands.Models
{
    public class DeleteExamTypeCommand : IRequest<Response<string>>
    {
        public int ExamTypeID { get; set; }
    }
}
