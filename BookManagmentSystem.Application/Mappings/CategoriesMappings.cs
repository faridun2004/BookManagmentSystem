using AutoMapper;
using BookManagmentSystem.Application.CQRS.Categories.Commands;
using BookManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.Mappings
{
    public class CategoriesMappings: Profile
    {
        public CategoriesMappings() 
        {
            CreateMap<CreateCategoryCommand, Category>();

        }
    }
}
