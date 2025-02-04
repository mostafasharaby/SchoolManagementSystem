using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data
{
    public class Student
    {
        public int StudentID { get; set; } // Primary Key
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }
        public DateTime? StudentDateOfBirth { get; set; }
        public string? StudentGender { get; set; }
        public string? StudentAddress { get; set; }
        public string? StudentPhoneNumber { get; set; }
        public string? StudentEmail { get; set; }
        public int? ParentID { get; set; } // Foreign Key
        public int ?ClassroomID { get; set; } // Foreign Key

        public Parent ? Parent { get; set; }
        public Classroom? Classroom { get; set; }
    }
}
