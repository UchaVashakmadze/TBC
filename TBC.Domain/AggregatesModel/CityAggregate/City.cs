using System.Collections.Generic;
using Common.Domain.SeedWork;
using TBC.Domain.AggregatesModel.PersonAggregate;

namespace TBC.Domain.AggregatesModel.CityAggregate
{
    public class City : Entity<int>, IAggregateRoot
    {
        protected City()
        {
            PersonAddresses = new HashSet<PersonAddress>();
        }

        private City(string name) : this()
        {
            Name = name;
        }

        public string Name { get; private set; }

        public virtual ICollection<PersonAddress> PersonAddresses { get; private set; }

        public static City Create(
            string name)
        {
            return new City(name);
        }

        public void Update(
            string name)
        {
            if (Name != name)
                Name = name;
        }
    }
}
