using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AbcLearningHub.Data.Entities;
namespace AbcLearningHub.Data.DataAccess
{
    public class AbcLearningHubContext:DbContext
    {
       
        public AbcLearningHubContext(DbContextOptions<AbcLearningHubContext> options)
           : base(options)
        {
        }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseExam> CourseExams { get; set; }
        public virtual DbSet<UserCourse> UserCourses { get; set; }
        public virtual DbSet<UserCourseExam> UserCourseExams { get; set; }
        public virtual DbSet<UserCourseExamCertificate> UserCourseExamCertificates { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
    }
}
