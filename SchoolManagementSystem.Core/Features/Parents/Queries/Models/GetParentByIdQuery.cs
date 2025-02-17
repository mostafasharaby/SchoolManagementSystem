using MediatR;
using SchoolManagementSystem.Core.Bases;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Features.Parents.Queries.Models
{
    public class GetParentByIdQuery : IRequest<Response<Parent>>
    {
        public int ParentID { get; set; }

        public GetParentByIdQuery(int parentID)
        {
            ParentID = parentID;
        }
    }
}
