using MediatR;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetTeacherByIdQuery : IRequest<Teacher>
    {
        public int TeacherID { get; }

        public GetTeacherByIdQuery(int studentID)
        {
            TeacherID = studentID;
        }
    }
}
