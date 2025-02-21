using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Services.Abstracts;

namespace SchoolManagementSystem.Services.ImpelmentationService
{
    internal class ValidationService : IValidationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ValidationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private async Task ValidateEntityExistsAsync<T>(Func<int, Task<T>> getByIdFunc, int id, string entityName) // very clever idea :)
        {
            if (await getByIdFunc(id) == null)
            {
                throw new KeyNotFoundException($"{entityName} not found.");
            }
        }

        public Task ValidateStudentExistsAsync(int studentID) =>
            ValidateEntityExistsAsync(_unitOfWork.Students.GetByIdAsync, studentID, "Student");

        public Task ValidateLibraryExistsAsync(int libraryID) =>
            ValidateEntityExistsAsync(_unitOfWork.Library.GetByIdAsync, libraryID, "Library");

        public Task ValidateAssignmentExistsAsync(int AssignmentID) =>
            ValidateEntityExistsAsync(_unitOfWork.Assignments.GetByIdAsync, AssignmentID, "Assignment");

        public Task ValidateCoursesExistsAsync(int CourseID) =>
            ValidateEntityExistsAsync(_unitOfWork.Courses.GetByIdAsync, CourseID, "Course");

        public Task ValidateBorrowedBookExistsAsync(int borrowID) =>
            ValidateEntityExistsAsync(_unitOfWork.BorrowedBooks.GetByIdAsync, borrowID, "BorrowedBook");

        public Task ValidateClassRoomExistsAsync(int ClassRoomId) =>
            ValidateEntityExistsAsync(_unitOfWork.Classrooms.GetByIdAsync, ClassRoomId, "Classroom");

        public Task ValidateDepartmentExistsAsync(int DepartmentID) =>
            ValidateEntityExistsAsync(_unitOfWork.Departments.GetByIdAsync, DepartmentID, "Department");

        public Task ValidateTeacherExistsAsync(int TeacherId) =>
            ValidateEntityExistsAsync(_unitOfWork.Teachers.GetByIdAsync, TeacherId, "Teacher");

        public Task ValidateExamsExistsAsync(int examID) =>
            ValidateEntityExistsAsync(_unitOfWork.Exams.GetByIdAsync, examID, "Exam");

        public Task ValidateExamsScoreExistsAsync(int ExamScoreID) =>
            ValidateEntityExistsAsync(_unitOfWork.ExamScores.GetByIdAsync, ExamScoreID, "ExamScore");

        public Task ValidateExamTypeExistsAsync(int examTypeID) =>
            ValidateEntityExistsAsync(_unitOfWork.ExamsTypes.GetByIdAsync, examTypeID, "ExamType");

        public Task ValidateParentExistsAsync(int parentId) =>
            ValidateEntityExistsAsync(_unitOfWork.Parents.GetByIdAsync, parentId, "Parent");

        public Task ValidateAttendanceExistsAsync(int attendenceID) =>
            ValidateEntityExistsAsync(_unitOfWork.Attendances.GetByIdAsync, attendenceID, "Attendance");

        public Task ValidateGradeExistsAsync(int gradeID) =>
            ValidateEntityExistsAsync(_unitOfWork.Grades.GetByIdAsync, gradeID, "Grade");

        public Task ValidateEnrollExistsAsync(int enrollID) =>
            ValidateEntityExistsAsync(_unitOfWork.Enrollments.GetByIdAsync, enrollID, "Enrollment");

        public Task ValidateExamResultExistsAsync(int examResultID) =>
            ValidateEntityExistsAsync(_unitOfWork.ExamResults.GetByIdAsync, examResultID, "ExamResult");

    }
}

