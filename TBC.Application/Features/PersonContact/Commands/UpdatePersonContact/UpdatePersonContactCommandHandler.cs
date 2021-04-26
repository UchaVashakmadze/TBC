using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Shared.Exceptions;
using MediatR;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.PersonContact.Commands.UpdatePersonContact
{
    public class UpdatePersonContactCommandHandler : IRequestHandler<UpdatePersonContactCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePersonContactCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdatePersonContactCommand request, CancellationToken cancellationToken)
        {
            var person = _unitOfWork.PersonRepository
                .GetPersonDatails(
                x => x.Id == request.PersonId
                     && !x.IsDeleted).FirstOrDefault();

            var personContactType = await _unitOfWork.PersonContactTypeRepository
                        .GetSingleAsync(
                            x => x.Id == request.PersonContactTypeId
                                 && !x.IsDeleted, cancellationToken);

            person.UpdatePersonContact(
                request.Id,
                personContactType,
                request.Value);

            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
