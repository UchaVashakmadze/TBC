using System.Threading;
using System.Threading.Tasks;
using Common.Shared.Exceptions;
using MediatR;
using TBC.Application.Services;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Persons.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public DeletePersonCommandHandler(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository
                .GetSingleAsync(
                x => x.Id == request.Id
                     && !x.IsDeleted, cancellationToken);

            person.Delete();

            //Delete Image
            if (!string.IsNullOrEmpty(person.Image))
            {
                _fileService.Remove(person.Image);
            }

            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
