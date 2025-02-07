using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class AddStudentCommandWithResponse : IRequest<Response<Student>>
    {

        public string? StudentLastNameAr { get; set; }
        public string? StudentLastNameEn { get; set; }
        public string? StudentGender { get; set; }
        public string? StudentAddress { get; set; }
        public int? ParentIDDD { get; set; }
        public int? ClassroomIDDD { get; set; }
        public string? StudentFirstNameAr { get; set; }
        public string? StudentFirstNameEn { get; set; }

    }
}
