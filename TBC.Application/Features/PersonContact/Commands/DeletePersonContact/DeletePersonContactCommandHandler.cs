using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.PersonContact.Commands.DeletePersonContact
{
    public class DeletePersonContactCommandHandler : IRequestHandler<DeletePersonContactCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonContactCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletePersonContactCommand request, CancellationToken cancellationToken)
        {
            var entity = _unitOfWork.PersonRepository
               .GetPersonDatails(
               x => x.Id == request.PersonId
                    && !x.IsDeleted).FirstOrDefault();

            entity.DeletePersonContact(request.Id);

            _unitOfWork.PersonRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
