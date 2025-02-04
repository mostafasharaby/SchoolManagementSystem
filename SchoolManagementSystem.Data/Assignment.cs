using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public class Assignment
    {
        public int AssignmentID { get; set; } // Primary Key
        public string? AssignmentName { get; set; }
        public int? CourseID { get; set; } // Foreign Key
        public DateTime? DueDate { get; set; }
    }
}
