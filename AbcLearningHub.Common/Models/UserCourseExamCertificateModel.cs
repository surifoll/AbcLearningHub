using System;

namespace AbcLearningHub.Common.Models
{
    public class UserCourseExamCertificateModel
    {
        public int Id { get; set; }
        public int UserCourseExamId { get; set; }
        public int UserCourseExamCourseName { get; set; }
        public DateTime DateCompleted { get; set; }
        public string Title { get; set; }
        public UserCourseExamModel UserCourseExam { get; set; }
    }
}
