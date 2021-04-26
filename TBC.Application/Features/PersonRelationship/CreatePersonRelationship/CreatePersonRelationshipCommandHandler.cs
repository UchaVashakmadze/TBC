using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.PersonRelationship.CreatePersonRelationship
{
    public class CreatePersonRelationshipCommandHandler : IRequestHandler<CreatePersonRelationshipCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonRelationshipCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreatePersonRelationshipCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PersonRepository
                .GetSingleAsync(
                x => x.Id == request.PersonId
                     && !x.IsDeleted, cancellationToken);

            var relatedPerson = await _unitOfWork.PersonRepository
                        .GetSingleAsync(
                            x => x.Id == request.RelatedPersonId
                                 && !x.IsDeleted, cancellationToken);

            var personsRelationshipType = await _unitOfWork.PersonsRelationshipTypeRepository
                        .GetSingleAsync(
                            x => x.Id == request.PersonsRelationshipTypeId
                                 && !x.IsDeleted, cancellationToken);

            entity.AddPersonRelationships(
                Domain.AggregatesModel.PersonAggregate.PersonRelationship.Create(
                    relatedPerson,
                    personsRelationshipType));

            _unitOfWork.PersonRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
