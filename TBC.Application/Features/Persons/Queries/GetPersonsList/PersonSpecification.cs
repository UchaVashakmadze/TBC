using System;
using System.Linq.Expressions;
using Common.Shared.Extentions.Lambda;
using Common.Shared.Specifications;
using TBC.Domain.AggregatesModel.PersonAggregate;

namespace TBC.Application.Features.Persons.Queries.GetPersonsList
{
    public class PersonSpecification : Specification<Person>
    {
        /// <summary>
        /// Global Variable
        /// </summary>
        /// Base Filter Expression
        private Expression<Func<Person, bool>> BaseExpression { get; set; } = u => !u.IsDeleted;

        //Filter Query
        private readonly GetPersonsQuery _filter;

        public PersonSpecification(GetPersonsQuery filter)
        {
            _filter = filter;
        }

        public override Expression<Func<Person, bool>> ToExpression()
        {
            var result = BaseExpression;

            if (_filter.Gender != 0)
                result = result.And(e => e.Gender == _filter.Gender);

            if (!string.IsNullOrWhiteSpace(_filter.FirstName))
            {
                result = result.And(e => e.Name.Firstname.ToLower().Contains(_filter.FirstName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(_filter.LastName))
            {
                result = result.And(e => e.Name.Lastname.ToLower().Contains(_filter.LastName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(_filter.SearchQuery))
            {
                result = result.And(e => 
                    e.Name.Firstname.ToLower().Contains(_filter.SearchQuery.ToLower())||
                    e.Name.Lastname.ToLower().Contains(_filter.SearchQuery.ToLower())
                );
            }

            if (_filter.BirthDate != null)
            {
                var frmDt = _filter.BirthDate.From ?? new DateTime(1900, 01, 01);
                var toDt = _filter.BirthDate.To ?? new DateTime(2100, 01, 01);
                result = result.And(e => e.BirthDate >= frmDt && e.BirthDate <= toDt);
            }

            return result;
        }
    }
}
