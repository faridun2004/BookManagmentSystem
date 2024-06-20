//using BookManagmentSystem.Application.Common.Interfaces;
//using BookManagmentSystem.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BookManagmentSystem.Application.Common.Services
//{
//    public class GenericService<T> : IBaseService<T> where T : BaseEntity
//    {
//        private readonly ISQLRepository<T> _repository;

//        public GenericService(ISQLRepository<T> repository)
//        {
//            _repository = repository;
//        }

//        public async Task<IEnumerable<T>> GetAllAsync()
//        {
//            return await _repository.GetAllAsync();
//        }

//        public async Task<T> GetByIdAsync(int id)
//        {
//            return await _repository.GetByIdAsync(id);
//        }

//        public async Task<int> AddAsync(T entity)
//        {
//            await _repository.AddAsync(entity);
//            return entity.GetHashCode(); // Или другой уникальный идентификатор
//        }

//        public async Task UpdateAsync(T entity)
//        {
//            await _repository.UpdateAsync(entity);
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var entity = await _repository.GetByIdAsync(id);
//            await _repository.DeleteAsync(entity);
//        }
//    }
//}
