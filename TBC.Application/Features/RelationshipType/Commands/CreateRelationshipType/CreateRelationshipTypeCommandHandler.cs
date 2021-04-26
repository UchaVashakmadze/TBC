using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TBC.Domain.AggregatesModel.PersonsRalationshipTypeAggregate;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.RelationshipType.Commands.CreateRelationshipType
{
    public class CreateRelationshipTypeCommandHandler : IRequestHandler<CreateRelationshipTypeCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRelationshipTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateRelationshipTypeCommand request, CancellationToken cancellationToken)
        {

            var entity = PersonsRelationshipType.Create(request.Name.Trim());

            await _unitOfWork.PersonsRelationshipTypeRepository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
