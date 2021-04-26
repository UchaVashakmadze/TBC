using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.ContactType.Commands.CreateContactType
{
    public class CreateContactTypeCommandHandler : IRequestHandler<CreateContactTypeCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateContactTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateContactTypeCommand request, CancellationToken cancellationToken)
        {

            var entity = Domain.AggregatesModel.PersonContactTypeAggregate.PersonContactType.Create(request.Name.Trim());

            await _unitOfWork.PersonContactTypeRepository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
