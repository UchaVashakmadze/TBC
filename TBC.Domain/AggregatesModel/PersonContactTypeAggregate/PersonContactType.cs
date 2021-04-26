using System.Collections.Generic;
using Common.Domain.SeedWork;
using TBC.Domain.AggregatesModel.PersonAggregate;

namespace TBC.Domain.AggregatesModel.PersonContactTypeAggregate
{
    public class PersonContactType : Entity<int>, IAggregateRoot
    {
        protected PersonContactType()
        {
            PersonContacts = new HashSet<PersonContact>();
        }

        private PersonContactType(string name) : this()
        {
            Name = name;
        }

        public string Name { get; private set; }

        public virtual ICollection<PersonContact> PersonContacts { get; private set; }

        public static PersonContactType Create(
            string name)
        {
            return new PersonContactType(name);
        }

        public void Update(
            string name)
        {
            if (Name != name)
                Name = name;
        }
    }
}
