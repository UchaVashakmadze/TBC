using System.Threading.Tasks;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.ContactType.Commands.UpdateContactType
{
    public class UpdateContactTypeCommandlValidator : AbstractValidator<UpdateContactTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateContactTypeCommandlValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(s => s.Id)
                .NotEmpty();
            RuleFor(m => m.Name)
                .NotEmpty()
                .MustAsync((s, t, r) => ContactTypeDoesNotExists(s.Id))
                .WithMessage(ValidationErrorMessages.ContactTypeDoesNotExists)
                .MustAsync((s, t, r) => ContactTypeAlreadyExists(s.Id, s.Name))
                .WithMessage(ValidationErrorMessages.ContactTypeAlreadyExists);

        }

        private async Task<bool> ContactTypeAlreadyExists(int id, string name)
        {
            if (await ContactTypeDoesNotExists(id))
            {
                var ContactType = await _unitOfWork.PersonContactTypeRepository.GetSingleAsync(x =>
                    x.Name.Trim().ToLower() == name.Trim().ToLower() && !x.IsDeleted);
                if (ContactType != null)
                {
                    return ContactType.Id == id;
                }
            }

            return true;
        }
        private async Task<bool> ContactTypeDoesNotExists(int id)
        {
            var ContactType = await _unitOfWork.PersonContactTypeRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return ContactType;
        }
    }
}
