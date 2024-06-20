
using BookManagmentSystem.Application.Common.Interfaces;
using BookManagmentSystem.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using BookManagmentSystem.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
