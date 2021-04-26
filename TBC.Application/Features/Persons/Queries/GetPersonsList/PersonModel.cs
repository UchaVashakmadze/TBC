using System;
using TBC.Domain.Enums;

namespace TBC.Application.Features.Persons.Queries.GetPersonsList
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

    }
}
