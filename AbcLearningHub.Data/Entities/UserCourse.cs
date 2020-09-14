using System;

namespace AbcLearningHub.Data.Entities
{
    public class UserCourse
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int CourseId { get; set; }
        public DateTime DateEnrolled { get; set; }
        public decimal? Score { get; set; }
    }
}
