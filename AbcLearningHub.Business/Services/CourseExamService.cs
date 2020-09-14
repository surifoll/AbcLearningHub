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
    public interface ICourseExamService
    {
        Task<CourseExamModel> Add(CourseExamModel model);
        Task<CourseExamModel> Get(int id);
        List<CourseExamModel> Get();
        Task<CourseExamModel> Update(CourseExamModel model);
    }
    public class CourseExamService: ICourseExamService
    {
        private readonly ICourseExamRepository _repository;
        private readonly IMapper _mapper;
        public CourseExamService(ICourseExamRepository courseRepository,
            IMapper mapper)
        {
            _repository = courseRepository;
            _mapper = mapper;
        }
        public async Task<CourseExamModel> Add(CourseExamModel model)
        {
            try
            {
                var entity = _mapper.Map<CourseExam>(model);
                
               await _repository.Insert(entity);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        public List<CourseExamModel> Get()
        {
            try
            {
                var entity =  _repository.Query("Course");
                if(entity==null) throw new Exception("CourseExam not found");

                return _mapper.Map<List<CourseExamModel>>(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<CourseExamModel> Get(int id)
        {
            try
            {
                var entity = await _repository.Find(id);
                if(entity==null) throw new Exception("CourseExam not found");
                return _mapper.Map<CourseExamModel>(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<CourseExamModel> Update(CourseExamModel model)
        {
            try
            {
                var entity = await _repository.Find(model.Id);
                if (entity == null) throw new Exception("CourseExam not found");

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
