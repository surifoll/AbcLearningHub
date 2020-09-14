using System;

namespace AbcLearningHub.Data.Entities
{
    public class UserCourseExam
    {
        public int Id { get; set; }
        public int UserCourseId { get; set; }
        public int CourseExamId { get; set; }
        public DateTime DateTaken { get; set; }
        public Course Course { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
