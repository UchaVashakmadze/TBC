using System;
using System.Linq.Expressions;
using Common.Shared.Extentions.Lambda;
using Common.Shared.Specifications;
using TBC.Domain.AggregatesModel.PersonsRalationshipTypeAggregate;

namespace TBC.Application.Features.RelationshipType.Queries.GetRelationshipTypes
{
    public class RelationshipTypeSpecification : Specification<PersonsRelationshipType>
    {
        /// <summary>
        /// Global Variable
        /// </summary>
        /// Base Filter Expression
        private Expression<Func<PersonsRelationshipType, bool>> BaseExpression { get; set; } = u => !u.IsDeleted;

        //Filter Query
        private readonly GetRelationshipTypesQuery _filter;

        public RelationshipTypeSpecification(GetRelationshipTypesQuery filter)
        {
            _filter = filter;
        }

        public override Expression<Func<PersonsRelationshipType, bool>> ToExpression()
        {
            var result = BaseExpression;

            if (!string.IsNullOrWhiteSpace(_filter.SearchQuery))
                result = result.And(e => e.Name.ToLower().Contains(_filter.SearchQuery.ToLower()));
            return result;
        }
    }
}
