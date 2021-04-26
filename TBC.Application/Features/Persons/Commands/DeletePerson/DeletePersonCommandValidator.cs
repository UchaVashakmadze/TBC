using System.Threading.Tasks;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Persons.Commands.DeletePerson
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(m => m.Id)
                .NotEmpty()
                .MustAsync((s, t, r) => CityDoesNotExists(s.Id))
                .WithMessage(ValidationErrorMessages.PersonDoesNotExists);
        }

        private async Task<bool> CityDoesNotExists(int id)
        {
            var city = await _unitOfWork.PersonRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return city;
        }
    }
}
