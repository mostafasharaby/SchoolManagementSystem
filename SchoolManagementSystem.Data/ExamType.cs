using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public class ExamType
    {
        public int ExamTypeID { get; set; } // Primary Key
        public string? TypeName { get; set; } // e.g., Midterm, Final, Quiz
    }

}
