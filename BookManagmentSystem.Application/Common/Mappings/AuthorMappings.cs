using AutoMapper;
using BookManagmentSystem.Application.CQRS.Authors.Commands.Create;
using BookManagmentSystem.Application.CQRS.Authors.Commands.Update;
using BookManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.Common.Mappings
{
    public class AuthorMappings : Profile
    {
        public AuthorMappings()
        {
            CreateMap<CreateAuthorCommand, Author>();
            CreateMap<UpdateAuthorCommand, Author>();

        }
    }
}
