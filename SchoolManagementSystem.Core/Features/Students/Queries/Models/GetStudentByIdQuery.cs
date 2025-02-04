using MediatR;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery:IRequest<Student>
    {
        public int StudentID { get; }

        public GetStudentByIdQuery(int studentID)
        {
            StudentID = studentID;
        }
    }
}
