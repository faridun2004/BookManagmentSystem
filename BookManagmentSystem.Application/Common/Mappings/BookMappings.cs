using AutoMapper;
using BookManagmentSystem.Application.CQRS.Books.Commands.Create;
using BookManagmentSystem.Application.CQRS.Books.Commands.Delete;
using BookManagmentSystem.Application.CQRS.Books.Commands.Update;
using BookManagmentSystem.Application.CQRS.Books.Queries.GetAll;
using BookManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.Common.Mappings
{
    public class BookMappings : Profile
    {
        public BookMappings()
        {
            CreateMap<GetAllBooksQuery, Book>();
            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();
            CreateMap<DeleteBookCommand, Book>();
        }

    }
}
