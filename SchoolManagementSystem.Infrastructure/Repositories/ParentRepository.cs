using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class ParentRepository : GenericRepository<Parent>, IParentRepository
    {
        public ParentRepository(SchoolContext dbContext) : base(dbContext)
        {
        }
    }
}
