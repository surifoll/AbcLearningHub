using AbcLearningHub.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbcLearningHub.Data.Repositories
{
    public interface ICourseExamRepository:IDataRepository<CourseExam>
    {

    }
    public class CourseExamRepository : DataRepository<CourseExam>, ICourseExamRepository
    {
        public CourseExamRepository(DbContext context) : base(context)
        {
        }
    }

   
}
