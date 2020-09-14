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
    public interface IAuthorService
    {
        Task<AuthorModel> Add(AuthorModel model);
        Task<AuthorModel> Get(int id);
        List<AuthorModel> Get();
        Task<AuthorModel> Update(AuthorModel model);
    }
    public class AuthorService: IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository courseRepository,
            IMapper mapper)
        {
            _repository = courseRepository;
            _mapper = mapper;
        }
        public async Task<AuthorModel> Add(AuthorModel model)
        {
            try
            {
                var entity = _mapper.Map<Author>(model);
               await _repository.Insert(entity);
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        public List<AuthorModel> Get()
        {
            try
            {
                var entity =  _repository.Query();
                if(entity==null) throw new Exception("Author not found");

                return _mapper.Map<List<AuthorModel>>(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<AuthorModel> Get(int id)
        {
            try
            {
                var entity = await _repository.Find(id);
                if(entity==null) throw new Exception("Author not found");
                return _mapper.Map<AuthorModel>(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<AuthorModel> Update(AuthorModel model)
        {
            try
            {
                var entity = await _repository.Find(model.Id);
                if (entity == null) throw new Exception("Author not found");

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
