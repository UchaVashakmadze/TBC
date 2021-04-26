using System;
using System.Linq;
using System.Linq.Expressions;
using Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TBC.Domain.AggregatesModel.PersonAggregate;
using TBC.Infrastructure.Persistence.Context;

namespace TBC.Infrastructure.Persistence.Repositories
{
    public class PersonRepository : GenericRepository<Person, PersonsDbContext>, IPersonRepository
    {
        public PersonRepository(PersonsDbContext context)
            : base(context)
        {
        }

        public IQueryable<PersonRelationship> GetAllPersonRelationships(Expression<Func<PersonRelationship, bool>> where)
        {
            return Context.PersonRelationships.Where(where)
                .Include(p => p.RelatedPerson)
                .Include(pp => pp.MainPerson)
                .Include(t => t.PersonsRelationshipType);
        }


        public IQueryable<Person> GetPersonDatails(Expression<Func<Person, bool>> where)
        {
            return Context.Persons.Where(where)
                .Include(c => c.PersonContacts.Where(w => !w.IsDeleted))
                .Include(a => a.PersonAddresses.Where(w => !w.IsDeleted))
                .Include(r => r.MainPersonRelationships.Where(w => !w.IsDeleted))
                .ThenInclude(rr => rr.RelatedPerson);
        }
    }
}
