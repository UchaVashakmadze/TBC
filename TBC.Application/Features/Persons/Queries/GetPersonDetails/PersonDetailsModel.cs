using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TBC.Domain.AggregatesModel.PersonAggregate;
using TBC.Domain.Enums;

namespace TBC.Application.Features.Persons.Queries.GetPersonDetails
{
    /// <summary>
    /// Person Detail Model 
    /// </summary>
    public class PersonDetailsModel
    {
        /// <summary>
        /// Firstname of the Person
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Lastname of the Person
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Personal Number of the Person
        /// </summary>
        public string PersonalNumber { get; set; }

        /// <summary>
        /// The Date of Birth of the Person
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// The Address of the Person
        /// </summary>
        public PersonAddressModel Address { get; set; }

        /// <summary>
        /// The Gender of the Person
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// The Image of the Person
        /// </summary>
        public byte[] File { get; set; }

        /// <summary>
        /// The The List of Contacts of the Person
        /// </summary>
        public IEnumerable<PersonContactModel> Contacts { get; set; }

        /// <summary>
        /// The The List of Related Persons of the Person
        /// </summary>
        public IEnumerable<PersonsRelationsModel> RelatedPersons { get; set; }

    }
}
