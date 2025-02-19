using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.DTO;

namespace SchoolManagementSystem.Core.Features.ExamsTypes.Commands.Models
{
    public class AddExamTypeCommand : ExamTypeDto, IRequest<Response<string>>
    {
    }

}
