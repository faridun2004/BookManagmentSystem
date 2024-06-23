using BookManagmentSystem.Domain.Entities;
using BookManagmentSystem.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.NUnit.CommonData
{
    public static class TestUtilities
    {
        public static void InitializeDbForTests(ApplicationDbContext dbContext)
        {
            // Пример инициализации базы данных для тестирования
            dbContext.Books.Add(new Book { Title = "Test Book 1", Price = 10 });
            dbContext.Books.Add(new Book { Title = "Test Book 2", Price = 20 });
            dbContext.SaveChanges();
        }
    }
}
