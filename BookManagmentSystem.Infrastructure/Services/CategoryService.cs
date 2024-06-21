using BookManagmentSystem.Application.Common.Interfaces;
using BookManagmentSystem.Application.InterfaceRepositories;
using BookManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Infrastructure.Services
{
    public class CategoryService :  ICategoryService
    {
        ISQLRepository<Category> _repository;
        public CategoryService(ISQLRepository<Category> repository)
        {
            _repository = repository;
        }

        public IQueryable<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Category> GetMan()
        {
            return _repository.GetAll();
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public Category TryCreate(Category item, out string message)
        {
            if (string.IsNullOrEmpty(item.Name))
            {
                message = "The first name or last name is be empty";
                return default;
            }
            else
            {
                return _repository.TryCreate(item, out message);
            }
        }

        public bool TryUpdate(Guid id, Category item, out string message)
        {
            var _item = _repository.GetById(id).GetAwaiter().GetResult();
            if (_item is null)
            {
                message = "Item not found";
                return false;
            }
            else
            {
                _item.Name = item.Name;

                return _repository.TryUpdate(_item, out message);
            }
        }

        public bool TryDelete(Guid id, out string message)
        {
            return _repository.TryDelete(id, out message);
        }
    }
}

