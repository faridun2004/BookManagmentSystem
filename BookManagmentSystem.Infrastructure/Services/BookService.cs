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
    public class BookService : IBookService
    {
        ISQLRepository<Book> _repository;
        public BookService(ISQLRepository<Book> repository)
        {
            _repository = repository;
        }

        public IQueryable<Book> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Book> GetAll(int skip, int take)
        {
            return _repository.GetAll().Skip(skip).Take(take);
        }

        public async Task<Book> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public Book TryCreate(Book item, out string message)
        {
            if (string.IsNullOrEmpty(item.Title) || string.IsNullOrEmpty(item.Author.ToString()))
            {
                message = "The first name or last name is be empty";
                return default;
            }


            return _repository.TryCreate(item, out message);
        }

        public bool TryUpdate(Guid id, Book item, out string message)
        {
            var _item = _repository.GetById(id).GetAwaiter().GetResult();
            if (_item is null)
            {
                message = "Item not found";
                return false;
            }
            else
            {
                _item.Title = item.Title;
                _item.Price = item.Price;
                _item.Category = item.Category;
                _item.Author = item.Author;

                return _repository.TryUpdate(_item, out message);
            }
        }

        public bool TryDelete(Guid id, out string message)
        {
            return _repository.TryDelete(id, out message);
        }
    }
}
