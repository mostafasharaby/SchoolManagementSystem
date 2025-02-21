using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        public GradeRepository(SchoolContext dbContext) : base(dbContext)
        {
        }
    }
}
