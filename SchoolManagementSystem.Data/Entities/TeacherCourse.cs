﻿namespace SchoolManagementSystem.Data.Entities
{
    public class TeacherCourse
    {
        // public int TeacherCourseID { get; set; }
        public string? TeacherID { get; set; }
        public Teacher? Teacher { get; set; }

        public int CourseID { get; set; }
        public Course? Course { get; set; }
    }

}
