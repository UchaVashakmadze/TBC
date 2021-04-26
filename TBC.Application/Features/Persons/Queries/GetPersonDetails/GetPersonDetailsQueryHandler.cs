using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TBC.Application.Services;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsQueryHandler : IRequestHandler<GetPersonDetailsQuery, PersonDetailsModel>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public GetPersonDetailsQueryHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<PersonDetailsModel> Handle(GetPersonDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = _unitOfWork.PersonRepository
               .GetPersonDatails(x =>
                       x.Id == request.Id
                       && !x.IsDeleted).FirstOrDefault();

            var detail = _mapper.Map<PersonDetailsModel>(entity);
            detail.File = await _fileService.Download(entity.Image);
            return detail;
        }
    }
}
