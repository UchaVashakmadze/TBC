using Common.Domain.SeedWork;
using TBC.Domain.AggregatesModel.PersonContactTypeAggregate;

namespace TBC.Domain.AggregatesModel.PersonAggregate
{
    public class PersonContact : Entity<int>
    {
        // ReSharper disable once UnusedMember.Local
        private PersonContact()
        {

        }
        private PersonContact(
            PersonContactType personContactType, 
            string value)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            PersonContactType = personContactType;
            Value = value;
        }

        public string Value { get; private set; }
        public virtual PersonContactType PersonContactType { get; set; }
        public virtual Person Person { get; set; }

        public static PersonContact Create(
            PersonContactType personContactType,
            string value)
        {
            return new PersonContact(
                personContactType,
                value);
        }

        public void Update(PersonContactType personContactType, string value)
        {
            PersonContactType = personContactType;
            Value = value;
        }
    }
}
