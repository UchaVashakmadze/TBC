using System;
using System.Linq.Expressions;
using Common.Shared.Extentions.Lambda;
using Common.Shared.Specifications;

namespace TBC.Application.Features.Persons.Queries.GetPersonPersonRelationshipsList
{
    public class PersonRelationshipSpecification : Specification<Domain.AggregatesModel.PersonAggregate.PersonRelationship>
    {
        /// <summary>
        /// Global Variable
        /// </summary>
        /// Base Filter Expression
        private Expression<Func<Domain.AggregatesModel.PersonAggregate.PersonRelationship, bool>> BaseExpression { get; set; } = u =>!u.IsDeleted;

        //Filter Query
        private readonly GetPersonPersonRelationshipsQuery _filter;

        public PersonRelationshipSpecification(GetPersonPersonRelationshipsQuery filter)
        {
            _filter = filter;
        }

        public override Expression<Func<Domain.AggregatesModel.PersonAggregate.PersonRelationship, bool>> ToExpression()
        {
            var result = BaseExpression;

            if (!string.IsNullOrWhiteSpace(_filter.FirstName))
                result = result.And(e => e.MainPerson.Name.Firstname.ToLower().Contains(_filter.FirstName.ToLower()));

            if (!string.IsNullOrWhiteSpace(_filter.LastName))
                result = result.And(e => e.MainPerson.Name.Lastname.ToLower().Contains(_filter.LastName.ToLower()));

            if (_filter.PersonId != null)
                result = result.And(e => e.MainPerson.Id == _filter.PersonId);

            return result;
        }
    }
}
