﻿using BookManagmentSystem.Domain.Entities;
using BookManagmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using BookManagmentSystem.Application.InterfaceRepositories;

namespace BookManagmentSystem.Infrastructure.Repositories
{
    public class SQLRepository<T> : ISQLRepository<T> where T : BaseEntity
    {
        readonly ApplicationDbContext _context;
        public SQLRepository(ApplicationDbContext bankContext)
        {
            _context = bankContext;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(w => w.Id == id);
        }

        public T TryCreate(T item, out string message)
        {
            message = string.Empty;
            try
            {
                _context.Add(item);
                _ = _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return default;
        }

        public bool TryUpdate(T item, out string message)
        {
            message = string.Empty;
            try
            {
                _context.Update(item);
                var result = _context.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return false;
        }

        public bool TryDelete(Guid id, out string message)
        {
            message = string.Empty;
            try
            {
                var item = _context.Set<T>().SingleOrDefault(w => w.Id == id);
                if (item is not null)
                {
                    _context.Remove(item);
                    var result = _context.SaveChanges();
                    return result > 0;
                }
                else
                {
                    message = "Item not found";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return false;
        }

    }
}
