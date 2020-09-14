using System;

namespace AbcLearningHub.Common.Models
{
    public class UserCourseModel
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string UserProfileFirstName { get; set; }
        public DateTime DateEnrolled { get; set; }
        public decimal? Score { get; set; }
    }
}
