using SchoolManagementSystem.Data.Views;
using SchoolManagementSystem.Infrastructure.Basics;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IUserRolesClaimsRepository : IGenericRepository<UserRolesClaimsView>
    {
        Task<List<UserRolesClaimsView>> GetAllUserRoleClaims();
    }
}
