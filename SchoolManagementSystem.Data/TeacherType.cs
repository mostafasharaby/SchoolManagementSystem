using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public class TeacherType
    {
        public int TeacherTypeID { get; set; } // Primary Key
        public string? TypeName { get; set; } // e.g., Full-time, Part-time
    }
}
