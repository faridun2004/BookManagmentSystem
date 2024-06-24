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

namespace BookManagementSystem.NUnitTests.CommonData
{
    public abstract class CategoryTestEntity
    {
        protected ICategoryService _categoryService;
        protected ISQLRepository<Category> _repository;
        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<ISQLRepository<Category>>();
            _categoryService = new CategoryService(_repository);
        }
    }
}
