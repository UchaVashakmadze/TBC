using System.Threading;
using System.Threading.Tasks;
using Common.Shared.Exceptions;
using MediatR;
using TBC.Application.Services;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;
using TBC.Domain.ValueObjects;

namespace TBC.Application.Features.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public UpdatePersonCommandHandler(
            IUnitOfWork unitOfWork,
            IFileService fileService
        )
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository
                .GetSingleAsync(
                x => x.Id == request.Id
                     && !x.IsDeleted, cancellationToken);
            
            if (await _unitOfWork.PersonRepository
                .AnyAsync(x =>
                x.Id != person.Id
                && x.PersonalNumber == request.PersonalNumber.Trim()
                && !x.IsDeleted, cancellationToken))
            {
                throw new AlreadyExistsException(
                    StringResource.Person,
                    StringResource.PersonalNumber,
                    request.PersonalNumber);
            }

            //Image saving here
            var imgPath = string.Empty;
            if (request.Image != null)
                imgPath = await _fileService.Replace(request.Image, person.Image);

            person.Update(
                Name.Create(request.FirstName, request.LastName),
                PersonalNumber.Create(request.PersonalNumber),
                request.BirthDate,
                imgPath ?? person.Image,
                request.Gender
                );

            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
