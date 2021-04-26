using System.Collections.Generic;
using Common.Domain.SeedWork;
using TBC.Domain.AggregatesModel.PersonAggregate;

namespace TBC.Domain.AggregatesModel.PersonsRalationshipTypeAggregate
{
    public class PersonsRelationshipType : Entity<int>, IAggregateRoot
    {
        protected PersonsRelationshipType()
        {
            PersonsRelationships = new HashSet<PersonRelationship>();
        }

        private PersonsRelationshipType(string name) : this()
        {
            Name = name;
        }

        public string Name { get; private set; }

        public virtual ICollection<PersonRelationship> PersonsRelationships { get; private set; }

        public static PersonsRelationshipType Create(
            string name)
        {
            return new PersonsRelationshipType(name);
        }

        public void Update(
            string name)
        {
            if (Name != name)
                Name = name;
        }
    }
}
