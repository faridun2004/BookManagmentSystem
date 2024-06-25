using BookManagmentSystem.Infrastructure.Helpers;
using BookManagmentSystem.Infrastructure.Persistence;
using BookManagmentSystem.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using MediatR;
using BookManagmentSystem.Application.CQRS.Employees.Commands;
using BookManagmentSystem.Application.CQRS.Categories.Commands;
using BookManagmentSystem.Application.Common.Mappings;
using BookManagmentSystem.Application.CQRS.Authors.Commands.Create;
using BookManagmentSystem.Application.CQRS.Books.Commands.Create;
using FluentValidation;
using FluentValidation.AspNetCore;
using BookManagmentSystem.Application.CQRS.Authors.Commands.Delete;
using BookManagmentSystem.Application.CQRS.Authors.Commands.Update;
using BookManagmentSystem.Application.CQRS.Books.Commands.Delete;
using BookManagmentSystem.Application.CQRS.Books.Commands.Update;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddMyAuth();
        builder.Services.AddDbContext<ApplicationDbContext>(con => con.UseSqlServer(builder.Configuration["ConnectionString"])
                                   .LogTo(Console.Write, LogLevel.Error)
                                   .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        builder.Services.AddLogging();
        builder.Services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddAutoMapper(typeof(EmployeeMappings));
        builder.Services.AddAutoMapper(typeof(CategoriesMappings));
        builder.Services.AddAutoMapper(typeof(BookMappings));
        builder.Services.AddAutoMapper(typeof(AuthorMappings));
        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateEmployeeCommand).Assembly));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateAuthorCommand).Assembly));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateBookCommand).Assembly));
        builder.Services.AddFluentValidationAutoValidation();

        builder.Services.AddValidatorsFromAssemblyContaining<CreateBookCommandValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<DeleteBookCommandValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<UpdateBookCommandValidator>();

        builder.Services.AddValidatorsFromAssemblyContaining<CreateAuthorCommandValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<DeleteAuthorCommandValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<UpdateAuthorCommandValidator>();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Book application APIs", Version = "v1" });

            // Add the JWT Bearer authentication scheme
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description = "JWT Authorization header using the Bearer scheme.",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            };
            c.AddSecurityDefinition("Bearer", securityScheme);

            // Use the JWT Bearer authentication scheme globally
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                { securityScheme, new List<string>() }
                    });
        });
        builder.Services.AddMyServices();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
#if DEBUG
            if (builder.Environment.IsEnvironment("Test"))
            {
                context.Database.EnsureCreated();
            }
            else
            {
#endif
                context.Database.Migrate();
#if DEBUG
            }
#endif
        }
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}