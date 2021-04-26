using System;
using System.Linq;
using System.Linq.Expressions;
using Common.Domain.SeedWork;

namespace TBC.Domain.AggregatesModel.PersonAggregate
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        IQueryable<PersonRelationship> GetAllPersonRelationships(Expression<Func<PersonRelationship, bool>> where);
        IQueryable<Person> GetPersonDatails(Expression<Func<Person, bool>> where);
    }
}
