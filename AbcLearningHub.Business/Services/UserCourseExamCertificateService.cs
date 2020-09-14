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
    public interface IUserCourseExamCertificateService
    {
        Task<UserCourseExamCertificateModel> Add(UserCourseExamCertificateModel model);
        Task<UserCourseExamCertificateModel> Get(int id);
        List<UserCourseExamCertificateModel> Get();
        Task<UserCourseExamCertificateModel> Update(UserCourseExamCertificateModel model);
    }
    public class UserCourseExamCertificateService: IUserCourseExamCertificateService
    {
        private readonly IUserCourseExamCertificateRepository _repository;
        private readonly IMapper _mapper;
        public UserCourseExamCertificateService(IUserCourseExamCertificateRepository courseRepository,
            IMapper mapper)
        {
            _repository = courseRepository;
            _mapper = mapper;
        }
        public async Task<UserCourseExamCertificateModel> Add(UserCourseExamCertificateModel model)
        {
            try
            {
                var entity = _mapper.Map<UserCourseExamCertificate>(model);
               await _repository.Insert(entity);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        public List<UserCourseExamCertificateModel> Get()
        {
            try
            {
                var entity =  _repository.Query("UserCourseExam");
                if(entity==null) throw new Exception("UserCourseExamCertificate not found");

                return _mapper.Map<List<UserCourseExamCertificateModel>>(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<UserCourseExamCertificateModel> Get(int id)
        {
            try
            {
                var entity = await _repository.Find(id);
                if(entity==null) throw new Exception("UserCourseExamCertificate not found");
                return _mapper.Map<UserCourseExamCertificateModel>(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<UserCourseExamCertificateModel> Update(UserCourseExamCertificateModel model)
        {
            try
            {
                var entity = await _repository.Find(model.Id);
                if (entity == null) throw new Exception("UserCourseExamCertificate not found");

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
