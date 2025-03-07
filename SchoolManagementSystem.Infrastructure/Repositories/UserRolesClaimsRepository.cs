using SchoolManagementSystem.Data.Views;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class UserRolesClaimsRepository : GenericRepository<UserRolesClaimsView>, IUserRolesClaimsRepository
    {
        public UserRolesClaimsRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<UserRolesClaimsView>> GetAllUserRoleClaims() =>
            await GetAllAsync();
    }
}
