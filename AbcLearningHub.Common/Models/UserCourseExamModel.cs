using System;

namespace AbcLearningHub.Common.Models
{
    public class UserCourseExamModel
    {
        public int Id { get; set; }
        public int UserCourseId { get; set; }
        public int CourseExamId { get; set; }
        public string CourseName { get; set; }
        public DateTime DateTaken { get; set; }
    }
}
