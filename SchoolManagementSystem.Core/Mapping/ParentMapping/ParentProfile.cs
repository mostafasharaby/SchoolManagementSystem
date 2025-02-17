using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.ParentMapping
{
    public partial class ParentProfile : Profile
    {
        public ParentProfile()
        {
            AddParentCommandMapping();
            UpdateParentCommandMapping();
        }
    }
}
