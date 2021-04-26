using System.Threading;
using System.Threading.Tasks;
using TBC.Domain.AggregatesModel.CityAggregate;
using TBC.Domain.AggregatesModel.PersonAggregate;
using TBC.Domain.AggregatesModel.PersonContactTypeAggregate;
using TBC.Domain.AggregatesModel.PersonsRalationshipTypeAggregate;
using TBC.Domain.SeedWork;
using TBC.Infrastructure.Persistence.Context;

namespace TBC.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonsDbContext _context;
        public ICityRepository CityRepository { get; }
        public IPersonsRelationshipTypeRepository PersonsRelationshipTypeRepository { get; }
        public IPersonRepository PersonRepository { get; }
        public IPersonContactTypeRepository PersonContactTypeRepository { get; }

        public UnitOfWork(
            PersonsDbContext context, 
            ICityRepository cityRepository,
            IPersonsRelationshipTypeRepository personsRelationshipTypeRepository,
            IPersonRepository personRepository,
            IPersonContactTypeRepository personContactTypeRepository
        )
        {
            _context = context;
            CityRepository = cityRepository;
            PersonsRelationshipTypeRepository = personsRelationshipTypeRepository;
            PersonRepository = personRepository;
            PersonContactTypeRepository = personContactTypeRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return _context.BeginTransactionAsync(cancellationToken);
        }

        public Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            return _context.CommitTransactionAsync(cancellationToken);
        }

        public Task RollbackTransactionAsync(CancellationToken cancellationToken)
        {
            return _context.RollbackTransactionAsync(cancellationToken);
        }
    }
}
