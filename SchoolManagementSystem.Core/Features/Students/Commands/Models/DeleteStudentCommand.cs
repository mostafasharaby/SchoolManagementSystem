using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int StudentID { get; }

        public DeleteStudentCommand(int studentID)
        {
            StudentID = studentID;
        }
    }
}
