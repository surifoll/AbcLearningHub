using AbcLearningHub.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbcLearningHub.Data.Repositories
{
    public interface IUserCourseExamRepository:IDataRepository<UserCourseExam>
    {

    }
    public class UserCourseExamRepository : DataRepository<UserCourseExam>, IUserCourseExamRepository
    {
        public UserCourseExamRepository(DbContext context) : base(context)
        {
        }
    }

   
}
