using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Persons.Queries.GetPersonPersonRelationshipsList
{
    public class GetPersonPersonRelationshipsQueryHandler : IRequestHandler<GetPersonPersonRelationshipsQuery, IEnumerable<PersonRelationshipModel>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetPersonPersonRelationshipsQueryHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PersonRelationshipModel>> Handle(GetPersonPersonRelationshipsQuery request, CancellationToken cancellationToken)
        {
            var relations = _unitOfWork.PersonRepository.GetAllPersonRelationships(new PersonRelationshipSpecification(request).ToExpression()).ToList();

            return 
                from r in relations
                group r by new { r.MainPerson, r.PersonsRelationshipType } into g
                select new PersonRelationshipModel
                {
                    FirstName = g.Key.MainPerson.Name.Firstname,
                    LastName = g.Key.MainPerson.Name.Lastname,
                    RelationType = g.Key.PersonsRelationshipType.Name,
                    Count = g.Count()
                };

        }
    }
}
