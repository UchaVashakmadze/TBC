using System.Threading;
using System.Threading.Tasks;
using Common.Domain.SeedWork;
using TBC.Domain.AggregatesModel.CityAggregate;
using TBC.Domain.AggregatesModel.PersonAggregate;
using TBC.Domain.AggregatesModel.PersonContactTypeAggregate;
using TBC.Domain.AggregatesModel.PersonsRalationshipTypeAggregate;

namespace TBC.Domain.SeedWork
{
    public interface IUnitOfWork : IGenericUnitOfWork
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken);
        Task CommitTransactionAsync(CancellationToken cancellationToken);
        Task RollbackTransactionAsync(CancellationToken cancellationToken);

        public ICityRepository CityRepository { get; }
        public IPersonsRelationshipTypeRepository PersonsRelationshipTypeRepository { get; }
        public IPersonRepository PersonRepository { get; }
        public IPersonContactTypeRepository PersonContactTypeRepository { get; }
    }
}
