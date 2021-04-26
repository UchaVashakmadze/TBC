using Common.Infrastructure;
using TBC.Domain.AggregatesModel.PersonsRalationshipTypeAggregate;
using TBC.Infrastructure.Persistence.Context;

namespace TBC.Infrastructure.Persistence.Repositories
{
    public class PersonsRelationshipTypeRepository : GenericRepository<PersonsRelationshipType, PersonsDbContext>, IPersonsRelationshipTypeRepository
    {

        public PersonsRelationshipTypeRepository(PersonsDbContext context)
            : base(context)
        {
        }
    }
}
