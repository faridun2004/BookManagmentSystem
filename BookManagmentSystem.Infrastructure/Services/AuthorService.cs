using BookManagmentSystem.Application.Common.Interfaces;
using BookManagmentSystem.Domain.Entities;
using BookManagmentSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Infrastructure.Services
{
    public class AuthorService:  IAuthorService
    {
        ISQLRepository<Author> _repository;
        public AuthorService(ISQLRepository<Author> repository)
        {
            _repository = repository;
        }

        public IQueryable<Author> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Author> GetAll(int skip, int take)
        {
            return _repository.GetAll().Skip(skip).Take(take);
        }

        public async Task<Author> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public Author TryCreate(Author item, out string message)
        {
            if (string.IsNullOrEmpty(item.FullName) )
            {
                message = "The first name or last name is be empty";
                return default;
            }


            return _repository.TryCreate(item, out message);
        }

        public bool TryUpdate(Guid id, Author item, out string message)
        {
            var _item = _repository.GetById(id).GetAwaiter().GetResult();
            if (_item is null)
            {
                message = "Item not found";
                return false;
            }
            else
            {
                _item.FullName = item.FullName;

                return _repository.TryUpdate(_item, out message);
            }
        }

        public bool TryDelete(Guid id, out string message)
        {
            return _repository.TryDelete(id, out message);
        }
    }
}
