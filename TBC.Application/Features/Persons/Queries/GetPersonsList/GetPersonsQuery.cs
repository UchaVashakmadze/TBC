using System;
using Common.Shared.Base;
using MediatR;
using TBC.Common.SharedModels;
using TBC.Domain.Enums;

namespace TBC.Application.Features.Persons.Queries.GetPersonsList
{
    public class GetPersonsQuery : IBaseListQuery, IRequest<PagedList<PersonModel>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string SearchQuery { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DataRangeModel<DateTime?> BirthDate { get; set; }
        public Gender Gender { get; set; }

    }
}
