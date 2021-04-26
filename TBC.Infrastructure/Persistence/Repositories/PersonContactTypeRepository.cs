using Common.Infrastructure;
using TBC.Domain.AggregatesModel.PersonContactTypeAggregate;
using TBC.Infrastructure.Persistence.Context;

namespace TBC.Infrastructure.Persistence.Repositories
{
    public class PersonContactTypeRepository : GenericRepository<PersonContactType, PersonsDbContext>, IPersonContactTypeRepository
    {

        public PersonContactTypeRepository(PersonsDbContext context)
            : base(context)
        {
        }
    }
}
