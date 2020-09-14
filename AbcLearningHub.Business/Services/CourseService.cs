using AbcLearningHub.Common.Models;
using AbcLearningHub.Data.Entities;
using AbcLearningHub.Data.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AbcLearningHub.Business.Services
{
    public interface ICourseService
    {
        Task<CourseModel> Add(CourseModel model);
        Task<CourseModel> Get(int id);
        List<CourseModel> Get();
        Task<CourseModel> Update(CourseModel model);
    }
    public class CourseService: ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository courseRepository,
            IMapper mapper)
        {
            _repository = courseRepository;
            _mapper = mapper;
        }
        public async Task<CourseModel> Add(CourseModel model)
        {
            try
            {
                var entity = _mapper.Map<Course>(model);
                entity.DateCreated = DateTime.UtcNow;
               await _repository.Insert(entity);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        public List<CourseModel> Get()
        {
            try
            {
                var entity =  _repository.Query("Author");
                if(entity==null) throw new Exception("Course not found");

                return _mapper.Map<List<CourseModel>>(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<CourseModel> Get(int id)
        {
            try
            {
                var entity = await _repository.Find(id);
                if(entity==null) throw new Exception("Course not found");
                return _mapper.Map<CourseModel>(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<CourseModel> Update(CourseModel model)
        {
            try
            {
                var entity = await _repository.Find(model.Id);
                if (entity == null) throw new Exception("Course not found");

                _mapper.Map(model, entity); 
                await _repository.Update(entity);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
