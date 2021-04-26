using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.ContactType.Commands.DeleteContactType
{
    public class DeleteContactTypeCommandHandler : IRequestHandler<DeleteContactTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteContactTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteContactTypeCommand request, CancellationToken cancellationToken)
        {
            var ContactType = await _unitOfWork.PersonContactTypeRepository.GetSingleAsync(s => s.Id == request.Id && !s.IsDeleted, cancellationToken);
            ContactType.Delete();

            _unitOfWork.PersonContactTypeRepository.Update(ContactType);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
