using System.Threading;
using Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using TBC.Domain.AggregatesModel.CityAggregate;
using TBC.Domain.AggregatesModel.PersonAggregate;
using TBC.Domain.AggregatesModel.PersonsRalationshipTypeAggregate;

namespace TBC.Infrastructure.Persistence.Context
{
    public class PersonsDbContext : GenericDbContext
    {
        private IDbContextTransaction _currentTransaction;
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<PersonsRelationshipType> PersonRelationshipTypes { get; set; }
        public virtual DbSet<PersonRelationship> PersonRelationships { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PersonAddress> PersonAddresses { get; set; }
        public virtual DbSet<PersonContact> PersonContacts { get; set; }

        public PersonsDbContext(DbContextOptions<PersonsDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonsDbContext).Assembly);
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            _currentTransaction ??= await Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            try
            {
                await SaveChangesAsync(cancellationToken);
                if (_currentTransaction != null) await _currentTransaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await RollbackTransactionAsync(cancellationToken);
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
        {
            try
            {
                // ReSharper disable once PossibleNullReferenceException
                if (_currentTransaction != null) await _currentTransaction?.RollbackAsync(cancellationToken);
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

    }
}
