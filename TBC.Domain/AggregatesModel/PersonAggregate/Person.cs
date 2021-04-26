using System;
using System.Collections.Generic;
using System.Linq;
using Common.Domain.SeedWork;
using Common.Shared.Exceptions;
using TBC.Common.Resources;
using TBC.Domain.AggregatesModel.CityAggregate;
using TBC.Domain.AggregatesModel.PersonContactTypeAggregate;
using TBC.Domain.Enums;
using TBC.Domain.Exceptions;
using TBC.Domain.ValueObjects;

namespace TBC.Domain.AggregatesModel.PersonAggregate
{
    public class Person : Entity<int>, IAggregateRoot
    {
        protected Person()
        {
            MainPersonRelationships = new HashSet<PersonRelationship>();
            RelatedPersonRelationships = new HashSet<PersonRelationship>();
            PersonContacts = new HashSet<PersonContact>();
            PersonAddresses = new HashSet<PersonAddress>();
        }

        private Person(
            Name name,
            PersonalNumber personalNumber,
            DateTime birthDate,
            PersonAddress address,
            string image,
            Gender gender)
            : this()
        {
            Name = name;
            PersonalNumber = personalNumber;
            BirthDate = birthDate;
            AddPersonAddresses(address);
            Image = image;
            Gender = gender;
        }

        public virtual Name Name { get; private set; }
        public virtual PersonalNumber PersonalNumber { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Image { get; private set; }

        public Gender Gender { get; set; }
        public virtual ICollection<PersonRelationship> MainPersonRelationships { get; private set; }
        public virtual ICollection<PersonRelationship> RelatedPersonRelationships { get; private set; }
        public virtual ICollection<PersonContact> PersonContacts { get; private set; }
        public virtual ICollection<PersonAddress> PersonAddresses { get; private set; }

        public static Person Create(
            Name name,
            PersonalNumber personalNumber,
            DateTime birthDate,
            PersonAddress address,
            string image,
            Gender gender)
        {
            return new Person(
                name,
                personalNumber,
                birthDate,
                address,
                image,
                gender);
        }

        public void Update(Name name, PersonalNumber personalNumber, DateTime birthDate, string image, Gender gender)
        {
            if (!Name.Equals(name))
                Name = name;
            
            if (!PersonalNumber.Equals(personalNumber))
                PersonalNumber = personalNumber;

            if (!BirthDate.Equals(birthDate))
                BirthDate = birthDate;

            if (!Image.Equals(image))
                Image = image;

            if (!Gender.Equals(gender))
                Gender = gender;
        }

        private void AddPersonAddresses(params PersonAddress[] items)
        {
            if (items.Count() > 1 || PersonAddresses.Where(x =>!x.IsDeleted).Count() > 0)
            {
                throw new InvalidNumberOfPersonAddressesException();
            }

            foreach (var item in items)
            {
                PersonAddresses.Add(item);
            }
        }
        
        public void UpdatePersonAddress(City city, string value)
        {
            var address = PersonAddresses
                .FirstOrDefault(x => !x.IsDeleted);

            if (address == null)
            {
                PersonAddresses.Add(
                    PersonAddress.Create(city));
            }
            else
            {
                address.Update(city);
            }
        }

        public void DeletePersonAddress()
        {
            var address = PersonAddresses.FirstOrDefault(x => !x.IsDeleted);

            if (address == null)
            {
                throw new NotFoundException(
                    StringResource.PersonAddress,
                    StringResource.Person,
                    Id);
            }
            else
            {
                address.Delete();
            }
        }

        public Person AddPersonContacts(params PersonContact[] items)
        {
            foreach (var item in items)
            {
                PersonContacts.Add(item);
            }
            return this;
        }

        public void UpdatePersonContact(int id, PersonContactType personContactType, string value)
        {
            var contact = PersonContacts
                .FirstOrDefault(
                x => x.Id == id && !x.IsDeleted);

            if (contact == null)
            {
                throw new NotFoundException(
                    StringResource.Contact,
                    StringResource.Id,
                    id);
            }

            contact.Update(personContactType, value);
        }

        public void DeletePersonContact(int id)
        {
            var contact = PersonContacts
                .FirstOrDefault(
                x => x.Id == id  && !x.IsDeleted);

            if (contact == null)
            {
                throw new NotFoundException(
                    StringResource.Contact,
                    StringResource.Id,
                    id);
            }
            else
            {
                contact.Delete();
            }
        }

        public Person AddPersonRelationships(params PersonRelationship[] items)
        {
            foreach (var item in items)
            {
                MainPersonRelationships.Add(item);
            }
            return this;
        }

        public void DeletePersonRelationship(int id)
        {
            var personRelationship = 
                MainPersonRelationships.FirstOrDefault(x => x.Id == id && !x.IsDeleted) ??
                RelatedPersonRelationships.FirstOrDefault(x => x.Id == Id && !x.IsDeleted);

            if (personRelationship == null)
            {
                throw new NotFoundException(
                    StringResource.Relationship,
                    StringResource.Id,
                    id);
            }
            else
            {
                personRelationship.Delete();
            }
        }
    }
}
