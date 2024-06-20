using AutoMapper;
using BookManagmentSystem.Application.CQRS.Books.Commands;
using BookManagmentSystem.Application.CQRS.Books.Queries;
using BookManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.Mappings
{
    public class BookMappings: Profile
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
