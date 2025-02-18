﻿using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Basics;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    internal class AssignmentRepository : GenericRepository<Assignment>, IAssignmentRepository
    {
        private readonly SchoolContext _dbContext;
        public AssignmentRepository(SchoolContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async override Task<Assignment> GetByIdAsync(int id)
        {
            return await _dbContext.Assignments.AsNoTracking()
          .FirstOrDefaultAsync(b => b.AssignmentID == id);
        }

    }
}
