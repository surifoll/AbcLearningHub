using System;

namespace AbcLearningHub.Data.Entities
{
    public class UserCourseExamCertificate
    {
        public int Id { get; set; }
        public int UserCourseExamId { get; set; }
        public DateTime DateCompleted { get; set; }
        public string Title { get; set; }
        public UserCourseExam UserCourseExam { get; set; }
    }
}
