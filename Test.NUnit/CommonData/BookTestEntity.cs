using BookManagmentSystem.Application.InterfaceRepositories;
using BookManagmentSystem.Application.Interfaces;
using BookManagmentSystem.Domain.Entities;
using BookManagmentSystem.Infrastructure.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.NUnit.CommonData
{
    public abstract class BookTestEntity
    {
        protected IBookService _workerService;
        protected ISQLRepository<Book> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<ISQLRepository<Book>>();
            _workerService = new BookService(_repository);
        }
    }
}
