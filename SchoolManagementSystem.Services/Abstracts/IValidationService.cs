namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IValidationService
    {
        Task ValidateStudentExistsAsync(string studentID);
        Task ValidateLibraryExistsAsync(int libraryID);
        Task ValidateAssignmentExistsAsync(int AssignmentID);
        Task ValidateCoursesExistsAsync(int CourseID);
        Task ValidateBorrowedBookExistsAsync(int borrowID);
        Task ValidateClassRoomExistsAsync(int ClassRoomId);
        Task ValidateDepartmentExistsAsync(int DepartmentID);
        Task ValidateTeacherExistsAsync(string TeacherId);
        Task ValidateExamsExistsAsync(int examID);
        Task ValidateExamsScoreExistsAsync(int ExamScoreID);
        Task ValidateExamTypeExistsAsync(int examTypeID);
        Task ValidateParentExistsAsync(int parentId);
        Task ValidateAttendanceExistsAsync(int attendenceID);
        Task ValidateGradeExistsAsync(int gradeID);
        Task ValidateEnrollExistsAsync(int enrollID);
        Task ValidateExamResultExistsAsync(int examResultID);
    }
}
