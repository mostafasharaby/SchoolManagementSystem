using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.AssignmentMapping
{
    public partial class AssignmentProfile : Profile
    {
        public AssignmentProfile()
        {
            AssignmentCommandMapping();
        }
    }
}
