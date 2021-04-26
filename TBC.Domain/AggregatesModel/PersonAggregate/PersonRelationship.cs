using Common.Domain.SeedWork;
using TBC.Domain.AggregatesModel.PersonsRalationshipTypeAggregate;

namespace TBC.Domain.AggregatesModel.PersonAggregate
{
    public class PersonRelationship : Entity<int>
    {
        // ReSharper disable once UnusedMember.Local
        private PersonRelationship()
        {

        }
        private PersonRelationship(
            Person relatedPerson,
            PersonsRelationshipType personsRelationshipType)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RelatedPerson = relatedPerson;
            // ReSharper disable once VirtualMemberCallInConstructor
            PersonsRelationshipType = personsRelationshipType;
        }

        public virtual Person MainPerson { get; set; }
        public virtual Person RelatedPerson { get; set; }
        public virtual PersonsRelationshipType PersonsRelationshipType { get; set; }

        public static PersonRelationship Create(
            Person relatedPerson,
            PersonsRelationshipType personsRelationshipType)
        {
            return new PersonRelationship(
                relatedPerson,
                personsRelationshipType);
        }

    }
}
