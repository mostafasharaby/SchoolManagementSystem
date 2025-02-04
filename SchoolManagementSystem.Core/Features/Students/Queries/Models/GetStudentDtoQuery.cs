using MediatR;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentDtoQuery:IRequest<List<StudentDto>>
    {
    }
}
