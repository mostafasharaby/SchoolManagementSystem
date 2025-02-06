using MediatR;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Core.Features.Teachers.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Core.Features.Teachers.Queries.Models
{
    public class GetTeacherDtoQuery:IRequest<List<TeacherDto>>
    {
    }
}
