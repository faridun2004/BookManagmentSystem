﻿using BookManagmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Authors.Queries.GetById
{
    public class GetAuthorByIdQuery : IRequest<Author>
    {
        public Guid Id { get; set; }
    }
}
