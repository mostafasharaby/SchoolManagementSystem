using AutoMapper;

namespace SchoolManagementSystem.Core.Mapping.FeesMapping
{
    public partial class FeesProfile : Profile
    {
        public FeesProfile()
        {
            AddFeeCommandMapping();
            UpdateFeeCommandMapping();
            GetFeeQueryMapping();
        }

    }
}
