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
    public class EmployeeService: IEmployeeService
    {
        ISQLRepository<Employee> _repository;
        public EmployeeService(ISQLRepository<Employee> repository)
        {
            _repository = repository;
        }

        public IQueryable<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Employee> GetMan()
        {
            return _repository.GetAll();
        }

        public async Task<Employee> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public Employee TryCreate(Employee item, out string message)
        {
            if (string.IsNullOrEmpty(item.FullName)|| string.IsNullOrEmpty(item.LastName))
            {
                message = "The first name or last name is be empty";
                return default;
            }
            else
            {
                return _repository.TryCreate(item, out message);
            }
        }

        public bool TryUpdate(Guid id, Employee item, out string message)
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
                _item.Username = item.Username;
                _item.Password = item.Password;
                _item.Address   = item.Address;
                _item.Role = item.Role;
                

                return _repository.TryUpdate(_item, out message);
            }
        }

        public bool TryDelete(Guid id, out string message)
        {
            return _repository.TryDelete(id, out message);
        }
    }
}

