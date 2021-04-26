using System.Threading.Tasks;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.PersonContact.Commands.DeletePersonContact
{
    public class DeletePersonContactCommandValidator : AbstractValidator<DeletePersonContactCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonContactCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(m => m.Id).NotEmpty();
            RuleFor(m => m.PersonId)
                .NotEmpty()
                .MustAsync((s, t, r) => PersonDoesNotExists(s.PersonId)).WithMessage(ValidationErrorMessages.PersonDoesNotExists);
        }

        private async Task<bool> PersonDoesNotExists(int id)
        {
            var person = await _unitOfWork.PersonRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return person;
        }
    }
}
