using System.Threading.Tasks;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.ContactType.Commands.DeleteContactType
{
    public class DeleteContactTypeCommandlValidator : AbstractValidator<DeleteContactTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteContactTypeCommandlValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(s => s.Id)
                .NotEmpty()
                .MustAsync((s, t, r) => ContactTypeDoesNotExists(s.Id))
                .WithMessage(ValidationErrorMessages.ContactTypeDoesNotExists);
        }

        private async Task<bool> ContactTypeDoesNotExists(int id)
        {
            var ContactType = await _unitOfWork.PersonContactTypeRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return ContactType;
        }
    }
}
