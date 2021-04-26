using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Shared.Exceptions;
using MediatR;
using TBC.Application.Services;
using TBC.Common.Resources;
using TBC.Domain.AggregatesModel.PersonAggregate;
using TBC.Domain.SeedWork;
using TBC.Domain.ValueObjects;

namespace TBC.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public CreatePersonCommandHandler(
            IUnitOfWork unitOfWork,
            IFileService fileService
        )
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.PersonRepository.AnyAsync(x => x.PersonalNumber == request.PersonalNumber.Trim() && !x.IsDeleted, cancellationToken))
            {
                throw new AlreadyExistsException(
                    StringResource.Person,
                    StringResource.PersonalNumber,
                    request.PersonalNumber);
            }


            var city = await _unitOfWork.CityRepository.GetSingleAsync(x => x.Id == request.CityId && !x.IsDeleted, cancellationToken);

            //Image saving here
            var imgPath = string.Empty;
            if (request.Image != null)
                imgPath = await _fileService.Upload(request.Image);

            var entity = Person.Create(
                Name.Create(
                    request.FirstName,
                    request.LastName),
                PersonalNumber.Create(
                    request.PersonalNumber),
                request.BirthDate,
                PersonAddress.Create(
                    city),
                imgPath,
                request.Gender
            );


            await _unitOfWork.PersonRepository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
