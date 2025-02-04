using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; } // Primary Key
        public int? StudentID { get; set; } // Foreign Key
        public int? CourseID { get; set; } // Foreign Key
        public DateTime ?EnrollmentDate { get; set; }
    }
}
