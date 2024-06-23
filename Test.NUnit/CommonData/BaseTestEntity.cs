using BookManagmentSystem.Infrastructure.Services;
using BookManagmentSystem.Domain.Entities;
using BookManagmentSystem.Application.InterfaceRepositories;
using BookManagmentSystem.Application.Interfaces;
using NSubstitute;

namespace Test.NUnit.CommonData
{
    public abstract class BaseTestEntity
    {
        protected IEmployeeService _workerService;
        protected ISQLRepository<Employee> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<ISQLRepository<Employee>>();
            _workerService = new EmployeeService(_repository);
        }
        
    }
}
