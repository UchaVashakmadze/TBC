using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.ContactType.Commands.UpdateContactType
{
    public class UpdateContactTypeCommandHandler : IRequestHandler<UpdateContactTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateContactTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateContactTypeCommand request, CancellationToken cancellationToken)
        {
            var ContactType = await _unitOfWork.PersonContactTypeRepository.GetSingleAsync(s => s.Id == request.Id && !s.IsDeleted, cancellationToken);
            ContactType.Update(request.Name);

            _unitOfWork.PersonContactTypeRepository.Update(ContactType);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
