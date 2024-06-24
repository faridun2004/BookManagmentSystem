using BookManagmentSystem.Application.InterfaceRepositories;
using BookManagmentSystem.Application.Interfaces;
using BookManagmentSystem.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagmentSystem.Infrastructure.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMyServices(this IServiceCollection service)
        {
            service.AddScoped<AuthService>();
            service.AddScoped<IEmployeeService, EmployeeService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<IAuthorService, AuthorService>();
            service.AddScoped(typeof(ISQLRepository<>), typeof(SQLRepository<>));
        }
    }
}
