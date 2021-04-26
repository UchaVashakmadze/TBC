using System.Threading.Tasks;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.ContactType.Commands.CreateContactType
{
    public class CreateContactTypeCommandlValidator : AbstractValidator<CreateContactTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateContactTypeCommandlValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(m => m.Name)
                .NotEmpty()
                .MustAsync((s, t) => ContactTypeAlreadyExists(s))
                .WithMessage(ValidationErrorMessages.ContactTypeAlreadyExists);
        }

        private async Task<bool> ContactTypeAlreadyExists(string name)
        {
            var ContactType =  await _unitOfWork.PersonContactTypeRepository.AnyAsync(x => x.Name.Trim().ToLower() == name.Trim().ToLower() && !x.IsDeleted);
            return !ContactType;
        }
    }
}
