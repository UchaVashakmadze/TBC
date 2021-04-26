using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Shared.Base;
using MediatR;
using TBC.Domain.AggregatesModel.PersonContactTypeAggregate;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.ContactType.Queries.GetContactTypes
{
    public class GetContactTypesQueryHandler : IRequestHandler<GetContactTypesQuery, PagedList<ContactTypeModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetContactTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<ContactTypeModel>> Handle(GetContactTypesQuery query, CancellationToken cancellationToken)
        {
            var contactTypes = _unitOfWork.PersonContactTypeRepository.GetAll(new ContactTypeSpecification(query).ToExpression());
            var pagedList = await PagedList<PersonContactType>.Create(_unitOfWork.PersonContactTypeRepository, contactTypes, query.PageNumber, query.PageSize, _mapper, cancellationToken);
            return _mapper.Map<PagedList<ContactTypeModel>>(pagedList);
        }
    }
}
