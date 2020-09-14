using AbcLearningHub.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbcLearningHub.Data.Repositories
{
    public interface ICourseRepository:IDataRepository<Course>
    {

    }
    public class CourseRepository : DataRepository<Course>, ICourseRepository
    {
        public CourseRepository(DbContext context) : base(context)
        {
        }
    }

   
}
