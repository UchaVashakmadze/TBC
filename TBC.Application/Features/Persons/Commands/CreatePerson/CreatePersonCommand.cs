using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using TBC.Domain.Enums;

namespace TBC.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public IFormFile Image { get; set; }
        public int CityId { get; set; }
    }
}
