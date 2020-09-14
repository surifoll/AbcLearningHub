using AbcLearningHub.Common.Models;
using AbcLearningHub.Data.Entities;
using AutoMapper;

namespace SbscLearning.Web.Mappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseModel>();
            CreateMap<CourseModel, Course>();
            CreateMap<AuthorModel, Author>();
            CreateMap<Author, AuthorModel>();
            CreateMap<CourseExamModel, CourseExam>();
            CreateMap<CourseExam, CourseExamModel>();
            CreateMap<UserCourseExamCertificateModel, UserCourseExamCertificate>();
            CreateMap<UserCourseExamCertificate, UserCourseExamCertificateModel>();
            CreateMap<UserCourseModel, UserCourse>();
            CreateMap<UserCourse, UserCourseModel>();
            CreateMap<UserProfile, UserProfileModel>();
            CreateMap<UserProfileModel, UserProfile>();
            CreateMap<UserCourseExamModel, UserCourseExam>();
            CreateMap<UserCourseExam, UserCourseExamModel>();
        }
    }
}


