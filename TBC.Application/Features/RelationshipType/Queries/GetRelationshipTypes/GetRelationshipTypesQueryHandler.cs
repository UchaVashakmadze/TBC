using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Shared.Base;
using MediatR;
using TBC.Domain.AggregatesModel.PersonsRalationshipTypeAggregate;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.RelationshipType.Queries.GetRelationshipTypes
{
    public class GetRelationshipTypesQueryHandler : IRequestHandler<GetRelationshipTypesQuery, PagedList<RelationshipTypeModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRelationshipTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<RelationshipTypeModel>> Handle(GetRelationshipTypesQuery query, CancellationToken cancellationToken)
        {
            var contactTypes = _unitOfWork.PersonsRelationshipTypeRepository.GetAll(new RelationshipTypeSpecification(query).ToExpression());
            var pagedList = await PagedList<PersonsRelationshipType>.Create(_unitOfWork.PersonsRelationshipTypeRepository, contactTypes, query.PageNumber, query.PageSize, _mapper, cancellationToken);
            return _mapper.Map<PagedList<RelationshipTypeModel>>(pagedList);
        }
    }
}
