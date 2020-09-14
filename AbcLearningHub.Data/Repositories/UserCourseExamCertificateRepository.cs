using AbcLearningHub.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbcLearningHub.Data.Repositories
{
    public interface IUserCourseExamCertificateRepository:IDataRepository<UserCourseExamCertificate>
    {

    }
    public class UserCourseExamCertificateRepository : DataRepository<UserCourseExamCertificate>, IUserCourseExamCertificateRepository
    {
        public UserCourseExamCertificateRepository(DbContext context) : base(context)
        {
        }
    }

   
}
