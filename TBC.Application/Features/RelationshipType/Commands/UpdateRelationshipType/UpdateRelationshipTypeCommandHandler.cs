using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.RelationshipType.Commands.UpdateRelationshipType
{
    public class UpdateRelationshipTypeCommandHandler : IRequestHandler<UpdateRelationshipTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRelationshipTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateRelationshipTypeCommand request, CancellationToken cancellationToken)
        {
            var RelationshipType = await _unitOfWork.PersonsRelationshipTypeRepository.GetSingleAsync(s => s.Id == request.Id && !s.IsDeleted, cancellationToken);
            RelationshipType.Update(request.Name);

            _unitOfWork.PersonsRelationshipTypeRepository.Update(RelationshipType);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
