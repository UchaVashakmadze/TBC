using System.Collections.Generic;
using Common.Domain.SeedWork;

namespace TBC.Domain.ValueObjects
{
    public class PersonalNumber : ValueObject
    {
        public string Value { get;}

        protected PersonalNumber()
        {
        }

        private PersonalNumber(string value)
            : this()
        {
            Value = value;
        }

        public static PersonalNumber Create(string value)
        {
            value = value.Trim();

            return new PersonalNumber(value);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static implicit operator string(PersonalNumber personalNumber)
        {
            return personalNumber.Value;
        }

    }
}
