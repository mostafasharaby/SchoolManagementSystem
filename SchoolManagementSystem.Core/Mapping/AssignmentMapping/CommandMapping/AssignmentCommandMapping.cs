using SchoolManagementSystem.Core.Features.Assignments.Commands.Models;
using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.AssignmentMapping
{
    public partial class AssignmentProfile
    {
        public void AssignmentCommandMapping()
        {
            CreateMap<AddAssignmentCommand, Assignment>();
            CreateMap<UpdateAssignmentCommand, Assignment>();
            CreateMap<Assignment, AssignmentDto>();
        }
    }
}
