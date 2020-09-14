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
    public interface IUserCourseService
    {
        Task<UserCourseModel> Add(UserCourseModel model);
        Task<UserCourseModel> Get(int id);
        List<UserCourseModel> Get();
        Task<UserCourseModel> Update(UserCourseModel model);
    }
    public class UserCourseService: IUserCourseService
    {
        private readonly IUserCourseRepository _repository;
        private readonly IMapper _mapper;
        public UserCourseService(IUserCourseRepository courseRepository,
            IMapper mapper)
        {
            _repository = courseRepository;
            _mapper = mapper;
        }
        public async Task<UserCourseModel> Add(UserCourseModel model)
        {
            try
            {
                var entity = _mapper.Map<UserCourse>(model);
               await _repository.Insert(entity);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        public List<UserCourseModel> Get()
        {
            try
            {
                var entity =  _repository.Query();
                if(entity==null) throw new Exception("UserCourse not found");

                return _mapper.Map<List<UserCourseModel>>(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<UserCourseModel> Get(int id)
        {
            try
            {
                var entity = await _repository.Find(id);
                if(entity==null) throw new Exception("UserCourse not found");
                return _mapper.Map<UserCourseModel>(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<UserCourseModel> Update(UserCourseModel model)
        {
            try
            {
                var entity = await _repository.Find(model.Id);
                if (entity == null) throw new Exception("UserCourse not found");

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
