using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.Data;
namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetAllStudentsQuery : IRequest<List<Student>>
    {
    }
}
