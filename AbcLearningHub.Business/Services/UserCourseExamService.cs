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
    public interface IUserCourseExamService
    {
        Task<UserCourseExamModel> Add(UserCourseExamModel model);
        Task<UserCourseExamModel> Get(int id);
        List<UserCourseExamModel> Get();
        Task<UserCourseExamModel> Update(UserCourseExamModel model);
    }
    public class UserCourseExamService: IUserCourseExamService
    {
        private readonly IUserCourseExamRepository _repository;
        private readonly IMapper _mapper;
        public UserCourseExamService(IUserCourseExamRepository courseRepository,
            IMapper mapper)
        {
            _repository = courseRepository;
            _mapper = mapper;
        }
        public async Task<UserCourseExamModel> Add(UserCourseExamModel model)
        {
            try
            {
                var entity = _mapper.Map<UserCourseExam>(model);
               await _repository.Insert(entity);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        public List<UserCourseExamModel> Get()
        {
            try
            {
                var entity =  _repository.Query("Course");
                if(entity==null) throw new Exception("UserCourseExam not found");

                return _mapper.Map<List<UserCourseExamModel>>(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<UserCourseExamModel> Get(int id)
        {
            try
            {
                var entity = await _repository.Find(id);
                if(entity==null) throw new Exception("UserCourseExam not found");
                return _mapper.Map<UserCourseExamModel>(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<UserCourseExamModel> Update(UserCourseExamModel model)
        {
            try
            {
                var entity = await _repository.Find(model.Id);
                if (entity == null) throw new Exception("UserCourseExam not found");

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
