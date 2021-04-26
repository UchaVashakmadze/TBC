using FluentValidation;
using System.Threading.Tasks;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.PersonContact.Commands.CreatePersonContact
{
    public class CreatePersonContactModelValidator : AbstractValidator<CreatePersonContactCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePersonContactModelValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(m => m.PersonId)
                .NotEmpty()
                .MustAsync((s, t, r) => PersonDoesNotExists(s.PersonId)).WithMessage(ValidationErrorMessages.PersonDoesNotExists);
            RuleFor(m => m.PersonContactTypeId)
                .NotEmpty()
                .MustAsync((s, t, r) => ContactTypeDoesNotExists(s.PersonContactTypeId)).WithMessage(ValidationErrorMessages.ContactTypeDoesNotExists); 
            RuleFor(m => m.Value)
                .NotEmpty();
        }

        private async Task<bool> PersonDoesNotExists(int id)
        {
            var person = await _unitOfWork.PersonRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return person;
        }

        private async Task<bool> ContactTypeDoesNotExists(int id)
        {
            var contactType = await _unitOfWork.PersonContactTypeRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return contactType;
        }
    }
}
