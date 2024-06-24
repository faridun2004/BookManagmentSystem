using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Authors.Commands.Update
{
    public class UpdateAuthorCommand : IRequest<(bool, string)>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
