using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookManagmentSystem.Application.CQRS.Employees.Commands.Update
{
    public class UpdateEmployeeCommand : IRequest<(bool, string)>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

        public string? ContactInfo { get; set; }
        public string Role { get; set; }
    }
}
