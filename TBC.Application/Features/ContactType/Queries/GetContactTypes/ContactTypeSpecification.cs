using System;
using System.Linq.Expressions;
using Common.Shared.Extentions.Lambda;
using Common.Shared.Specifications;
using TBC.Domain.AggregatesModel.PersonContactTypeAggregate;

namespace TBC.Application.Features.ContactType.Queries.GetContactTypes
{
    public class ContactTypeSpecification : Specification<PersonContactType>
    {
        /// <summary>
        /// Global Variable
        /// </summary>
        /// Base Filter Expression
        private Expression<Func<PersonContactType, bool>> BaseExpression { get; set; } = u => !u.IsDeleted;

        //Filter Query
        private readonly GetContactTypesQuery _filter;

        public ContactTypeSpecification(GetContactTypesQuery filter)
        {
            _filter = filter;
        }

        public override Expression<Func<PersonContactType, bool>> ToExpression()
        {
            var result = BaseExpression;

            if (!string.IsNullOrWhiteSpace(_filter.SearchQuery))
                result = result.And(e => e.Name.ToLower().Contains(_filter.SearchQuery.ToLower()));
            return result;
        }
    }
}
