using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.PersonRelationship.DeletePersonRelationship
{
    public class DeletePersonRelationshipCommandHandler : IRequestHandler<DeletePersonRelationshipCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonRelationshipCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletePersonRelationshipCommand request, CancellationToken cancellationToken)
        {
            var entity = _unitOfWork.PersonRepository
               .GetPersonDatails(
               x => x.Id == request.PersonId
                    && !x.IsDeleted).FirstOrDefault();

            entity.DeletePersonRelationship(request.Id);

            _unitOfWork.PersonRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
