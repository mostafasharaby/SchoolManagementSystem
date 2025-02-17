using SchoolManagementSystem.Core.Features.Fees.Commands.Models;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Core.Mapping.FeesMapping
{
    public partial class FeesProfile
    {
        public void AddFeeCommandMapping()
        {
            CreateMap<CreateFeeCommand, Fee>();
        }
    }
}
