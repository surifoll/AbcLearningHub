using AbcLearningHub.Common.Models;
using AbcLearningHub.Data.Entities;
using AbcLearningHub.Data.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbcLearningHub.Business.Services
{
    public interface IUserProfileService
    {
        Task<UserProfileModel> Add(UserProfileModel model);
        Task<UserProfileModel> Get(int id);
        Task<UserProfileModel> Update(UserProfileModel model);
    }
    public class UserProfileService: IUserProfileService
    {
        private readonly IUserProfileRepository _repository;
        private readonly IMapper _mapper;
        public UserProfileService(IUserProfileRepository courseRepository,
            IMapper mapper)
        {
            _repository = courseRepository;
            _mapper = mapper;
        }
        public async Task<UserProfileModel> Add(UserProfileModel model)
        {
            try
            {
                var entity = _mapper.Map<UserProfile>(model);
                entity.DateCreated = DateTime.UtcNow;
               await _repository.Insert(entity);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<UserProfileModel> Get(int id)
        {
            try
            {
                var entity = await _repository.Find(id);
                if(entity==null) throw new Exception("User not found");
                return _mapper.Map<UserProfileModel>(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<UserProfileModel> Update(UserProfileModel model)
        {
            try
            {
                var entity = await _repository.Find(model.Id);
                if (entity == null) throw new Exception("User not found");

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
