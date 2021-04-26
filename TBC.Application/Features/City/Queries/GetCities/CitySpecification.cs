using System;
using System.Linq.Expressions;
using Common.Shared.Extentions.Lambda;
using Common.Shared.Specifications;

namespace TBC.Application.Features.City.Queries.GetCities
{
    public class CitySpecification : Specification<Domain.AggregatesModel.CityAggregate.City>
    {
        /// <summary>
        /// Global Variable
        /// </summary>
        /// Base Filter Expression
        private Expression<Func<Domain.AggregatesModel.CityAggregate.City, bool>> BaseExpression { get; set; } = u => !u.IsDeleted;

        //Filter Query
        private readonly GetCitiesQuery _filter;

        public CitySpecification(GetCitiesQuery filter)
        {
            _filter = filter;
        }

        public override Expression<Func<Domain.AggregatesModel.CityAggregate.City, bool>> ToExpression()
        {
            var result = BaseExpression;


            if (!string.IsNullOrWhiteSpace(_filter.SearchQuery))
                result = result.And(e => e.Name.ToLower().Contains(_filter.SearchQuery.ToLower()));
            return result;
        }
    }
}
