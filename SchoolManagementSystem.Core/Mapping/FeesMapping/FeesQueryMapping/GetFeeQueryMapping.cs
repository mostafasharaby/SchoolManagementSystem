using SchoolManagementSystem.Core.Features.Fees.Queries.Dto;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.FeesMapping
{

    public partial class FeesProfile
    {
        public void GetFeeQueryMapping()
        {
            CreateMap<Fee, FeeDto>();
        }

    }
}
