using System.Collections.Generic;
using Common.Domain.SeedWork;

namespace TBC.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string Firstname { get; }
        public string Lastname { get; }

        protected Name()
        {
        }

        private Name(string firstname, string lastname)
            : this()
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public static Name Create(string firstName, string lastName)
        {
            firstName = firstName.Trim();
            lastName = lastName.Trim();

            return new Name(firstName, lastName);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Firstname;
            yield return Lastname;
        }
    }
}
