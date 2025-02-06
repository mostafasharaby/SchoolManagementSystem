using MediatR;
using SchoolManagementSystem.Data;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class UpdateStudentCommandWithValidation : IRequest<Student>
    {
        public int StudentID { get; set; }
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }
        public string? StudentGender { get; set; }
        public string? StudentAddress { get; set; }
        public int? ParentIDDD { get; set; }
        public int? ClassroomIDDD { get; set; }

    }
}
