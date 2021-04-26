using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.PersonContact.Commands.CreatePersonContact
{
    public class CreatePersonContactCommandHandler : IRequestHandler<CreatePersonContactCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonContactCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreatePersonContactCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository
                .GetSingleAsync(
                x => x.Id == request.PersonId
                     && !x.IsDeleted, cancellationToken);
            
            var personContactType = await _unitOfWork.PersonContactTypeRepository
                        .GetSingleAsync(
                            x => x.Id == request.PersonContactTypeId
                                 && !x.IsDeleted, cancellationToken);

            person.AddPersonContacts(
                Domain.AggregatesModel.PersonAggregate.PersonContact.Create(
                    personContactType,
                    request.Value));

            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
