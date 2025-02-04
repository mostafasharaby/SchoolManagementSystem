using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Features.Teachers.Commands.Models
{
    public class DeleteTeacherCommand : IRequest<bool>
    {
        public int TeacherID { get; }

        public DeleteTeacherCommand(int teacherID)
        {
            TeacherID = teacherID;
        }
    }
}
