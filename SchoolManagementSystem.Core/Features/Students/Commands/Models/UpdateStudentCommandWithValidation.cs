using MediatR;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class UpdateStudentCommandWithValidation : IRequest<Student>
    {
        public int StudentID { get; set; }
        public string? StudentFirstNameEn { get; set; }
        public string? StudentLastNameAr { get; set; }
        public string? StudentFirstNameAr { get; set; }
        public string? StudentLastNameEn { get; set; }
        public string? StudentGender { get; set; }
        public string? StudentAddress { get; set; }
        public int? ParentIDDD { get; set; }
        public int? ClassroomIDDD { get; set; }

    }
}
