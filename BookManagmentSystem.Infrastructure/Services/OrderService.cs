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
    public class OrderService:  IOrderService
    {
        ISQLRepository<Order> _repository;
        public OrderService(ISQLRepository<Order> repository)
        {
            _repository = repository;
        }

        public IQueryable<Order> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Order> GetMan()
        {
            return _repository.GetAll();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public Order TryCreate(Order item, out string message)
        {
            if (string.IsNullOrEmpty(item.Customer.ToString()) || string.IsNullOrEmpty(item.CustomerId.ToString()))
            {
                message = "The first name or last name is be empty";
                return default;
            }
            else
            {
                return _repository.TryCreate(item, out message);
            }
        }

        public bool TryUpdate(Guid id, Order item, out string message)
        {
            var _item = _repository.GetById(id).GetAwaiter().GetResult();
            if (_item is null)
            {
                message = "Item not found";
                return false;
            }
            else
            {
                _item.OrderItems = item.OrderItems;
                _item.Customer = item.Customer;
                _item.CustomerId= item.CustomerId;  

                return _repository.TryUpdate(_item, out message);
            }
        }

        public bool TryDelete(Guid id, out string message)
        {
            return _repository.TryDelete(id, out message);
        }
    }
}

