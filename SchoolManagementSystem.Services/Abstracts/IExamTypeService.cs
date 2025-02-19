﻿using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Services.Abstracts
{
    public interface IExamTypeService
    {
        Task<bool> AddExamTypeAsync(ExamType examType);
        Task<bool> UpdateExamTypeAsync(ExamType examType);
        Task<bool> DeleteExamTypeAsync(int examTypeID);
        Task<ExamType?> GetExamTypeByIdAsync(int examTypeID);
        Task<List<ExamType>> GetAllExamTypesAsync();
    }

}
