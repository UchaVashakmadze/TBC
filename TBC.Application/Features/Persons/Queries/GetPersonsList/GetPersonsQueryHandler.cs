using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Shared.Base;
using MediatR;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Persons.Queries.GetPersonsList
{
    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, PagedList<PersonModel>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetPersonsQueryHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<PersonModel>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            var data = _unitOfWork.PersonRepository.GetAll(new PersonSpecification(request).ToExpression());

            return await PagedList<PersonModel>.Create(_unitOfWork.PersonRepository, data, request.PageNumber, request.PageSize, _mapper, cancellationToken);
        }
    }
}
