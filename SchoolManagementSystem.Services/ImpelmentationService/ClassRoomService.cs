using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;
using Serilog;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    public class ClassRoomService : IClassRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassRoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddclassRoomAsync(Classroom classroom)
        {
            await _unitOfWork.Classrooms.AddAsync(classroom);
            await _unitOfWork.CompleteAsync(); // Saves changes to the database
        }

        public async Task UpdateClassroomAsync(Classroom classroom)
        {
            await _unitOfWork.Classrooms.UpdateAsync(classroom);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteClassroomAsync(int classroomID)
        {
            var classroom = await _unitOfWork.Classrooms.GetByIdAsync(classroomID);
            if (classroom == null)
            {
                Log.Error("this student not exist");
                return false;

            }
            await _unitOfWork.Classrooms.DeleteAsync(classroom);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<Classroom> GetClassroomByIdAsync(int classroomID)
        {
            return await _unitOfWork.Classrooms.GetByIdAsync(classroomID);
        }

        public async Task<List<Classroom>> GetAllClassroomsAsync()
        {
            return await _unitOfWork.Classrooms.GetAllAsync();
        }

        public async Task<bool> AddClassroomWithStudentsAsync(Classroom classroom, List<Student> students)
        {
            return await _unitOfWork.ExecuteTransactionAsync(async () =>
            {
                await _unitOfWork.Classrooms.AddAsync(classroom);

                foreach (var student in students)
                {
                    student.ClassroomID = classroom.ClassroomID; // Assign student to this classroom
                    await _unitOfWork.Students.UpdateAsync(student);
                }
            });
        }
    }
}
