using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Features.Parents.Queries.Models
{
    public class GetAllParentsQuery : IRequest<Response<List<Parent>>> { }
}
