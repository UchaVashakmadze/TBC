using Common.Infrastructure;
using TBC.Domain.AggregatesModel.CityAggregate;
using TBC.Infrastructure.Persistence.Context;

namespace TBC.Infrastructure.Persistence.Repositories
{
    public class CityRepository : GenericRepository<City, PersonsDbContext>, ICityRepository
    {

        public CityRepository(PersonsDbContext context)
            : base(context)
        {
        }
    }
}
