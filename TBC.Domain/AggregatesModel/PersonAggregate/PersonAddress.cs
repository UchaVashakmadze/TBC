using Common.Domain.SeedWork;
using TBC.Domain.AggregatesModel.CityAggregate;

namespace TBC.Domain.AggregatesModel.PersonAggregate
{
    public class PersonAddress : Entity<int>
    {
        private PersonAddress()
        {
        }

        private PersonAddress(
            City city) : this()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Value = city.Name;
            CityId = city.Id;
        }

        public int CityId { get; private set; }
        public string Value { get; private set; }
        public virtual City City { get; set; }
        public virtual Person Person { get; set; }

        public static PersonAddress Create(
            City city)
        {
            return new PersonAddress(
                city);
        }

        public void Update(
            City city)
        {
            Value = city.Name;
            CityId = city.Id;
        }
    }
}
