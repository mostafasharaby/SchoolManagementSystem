using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class AddStudentCommandWithResponse:IRequest<Response<Student>>
    {     
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }       
        public string? StudentGender { get; set; }
        public string? StudentAddress { get; set; }      
        public int? ParentIDDD { get; set; } 
        public int? ClassroomIDDD { get; set; }

    }
}
