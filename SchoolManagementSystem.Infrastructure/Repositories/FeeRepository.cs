using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class FeeRepository : GenericRepository<Fee>, IFeeRepository
    {
        public FeeRepository(SchoolContext dbContext) : base(dbContext)
        {
        }
    }
}
