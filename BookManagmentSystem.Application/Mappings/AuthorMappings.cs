using AutoMapper;
using BookManagmentSystem.Application.CQRS.Authors.Commands;
using BookManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.Mappings
{
    public class AuthorMappings: Profile
    {
        public AuthorMappings() 
        { 
            CreateMap<CreateAuthorCommand, Author>();
            CreateMap<UpdateAuthorCommand, Author>();

        }
    }
}
