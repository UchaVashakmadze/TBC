using System.Threading.Tasks;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.PersonContact.Commands.UpdatePersonContact
{
    public class UpdatePersonContactModelValidator : AbstractValidator<UpdatePersonContactCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePersonContactModelValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(m => m.Id).NotEmpty();
            RuleFor(m => m.PersonContactTypeId)
                .NotEmpty()
                .MustAsync((s, t, r) => PersonContactTypeDoesNotExists(s.PersonContactTypeId)).WithMessage(ValidationErrorMessages.ContactTypeDoesNotExists); 
            RuleFor(m => m.PersonId)
                .NotEmpty()
                .MustAsync((s, t, r) => PersonDoesNotExists(s.PersonId)).WithMessage(ValidationErrorMessages.PersonDoesNotExists);
            RuleFor(m => m.Value).NotEmpty();
        }

        private async Task<bool> PersonDoesNotExists(int id)
        {
            var person = await _unitOfWork.PersonRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return person;
        }

        private async Task<bool> PersonContactTypeDoesNotExists(int id)
        {
            var contactType = await _unitOfWork.PersonContactTypeRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return contactType;
        }
    }
}
