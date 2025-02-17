﻿using SchoolManagementSystem.Infrastructure.Repositories;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        IClassRoomRepository Classrooms { get; }
        IStudentRepository Students { get; }
        IParentRepository Parents { get; }
        ITeacherRepository Teachers { get; }
        IBorrowedBookRepository BorrowedBooks { get; }
        ILibraryRepository Library { get; }
        IFeeRepository Fee { get; }
        // GenericRepository<Fee> Fee { get; }
        IUserRolesClaimsRepository UserRolesClaims { get; }
        Task<bool> ExecuteTransactionAsync(Func<Task> action);
        Task<int> CompleteAsync();
    }
}
