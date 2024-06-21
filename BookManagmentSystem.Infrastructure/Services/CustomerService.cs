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
    public class CustomerService: ICustomerService
    {
        ISQLRepository<Customer> _repository;
        public CustomerService(ISQLRepository<Customer> repository)
        {
            _repository = repository;
        }

        public IQueryable<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Customer> GetMan()
        {
            return _repository.GetAll();
        }

        public async Task<Customer> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public Customer TryCreate(Customer item, out string message)
        {
            if (string.IsNullOrEmpty(item.FullName) || string.IsNullOrEmpty(item.Email))
            {
                message = "The first name or last name is be empty";
                return default;
            }
            else
            {
                return _repository.TryCreate(item, out message);
            }
        }

        public bool TryUpdate(Guid id, Customer item, out string message)
        {
            var _item = _repository.GetById(id).GetAwaiter().GetResult();
            if (_item is null)
            {
                message = "Item not found";
                return false;
            }
            else
            {
                _item.FirstName = item.FirstName;
                _item.LastName = item.LastName;
                _item.Email = item.Email;
                _item.Address = item.Address;

                return _repository.TryUpdate(_item, out message);
            }
        }

        public bool TryDelete(Guid id, out string message)
        {
            return _repository.TryDelete(id, out message);
        }
    }
}


