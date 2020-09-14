using AbcLearningHub.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbcLearningHub.Data.Repositories
{
    public interface IUserCourseRepository:IDataRepository<UserCourse>
    {

    }
    public class UserCourseRepository : DataRepository<UserCourse>, IUserCourseRepository
    {
        public UserCourseRepository(DbContext context) : base(context)
        {
        }
    }

   
}
