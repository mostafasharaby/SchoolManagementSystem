using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public class Course
    {
        public int CourseID { get; set; } // Primary Key
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        public int? TeacherID { get; set; } // Foreign Key
        public int? DepartmentID { get; set; } // Foreign Key
    }
}
