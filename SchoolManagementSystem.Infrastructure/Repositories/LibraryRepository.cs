
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class LibraryRepository : GenericRepository<Library>, ILibraryRepository
    {
        public LibraryRepository(SchoolContext dbContext) : base(dbContext)
        {
        }
    }
}
