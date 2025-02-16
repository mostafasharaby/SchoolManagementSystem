using SchoolManagementSystem.Infrastructure.Repositories;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        IClassRoomRepository Classrooms { get; }
        IStudentRepository Students { get; }
        Task<bool> ExecuteTransactionAsync(Func<Task> action);
        Task<int> CompleteAsync();
    }
}
