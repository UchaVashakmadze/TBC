using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.RelationshipType.Commands.DeleteRelationshipType
{
    public class DeleteRelationshipTypeCommandHandler : IRequestHandler<DeleteRelationshipTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRelationshipTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteRelationshipTypeCommand request, CancellationToken cancellationToken)
        {
            var RelationshipType = await _unitOfWork.PersonsRelationshipTypeRepository.GetSingleAsync(s => s.Id == request.Id && !s.IsDeleted, cancellationToken);
            RelationshipType.Delete();

            _unitOfWork.PersonsRelationshipTypeRepository.Update(RelationshipType);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
