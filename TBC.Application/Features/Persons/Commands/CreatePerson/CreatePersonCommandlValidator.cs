using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Common.Shared.Extentions;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandlValidator : AbstractValidator<CreatePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatePersonCommandlValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(m => m.FirstName)
                .NotEmpty()
                .Length(2, 50)
                .Must(m =>
                    !string.IsNullOrWhiteSpace(m) &&
                    (Regex.IsMatch(m, "^[a-zA-Z]*$") || Regex.IsMatch(m, "^[ა-ჰ]*$")))
                .WithMessage(ValidationErrorMessages.UnicodeError);

            RuleFor(m => m.LastName)
                .NotEmpty()
                .Length(2, 50)
                .Must(m =>
                    !string.IsNullOrWhiteSpace(m) &&
                    (Regex.IsMatch(m, "^[a-zA-Z]*$") || Regex.IsMatch(m, "^[ა-ჰ]*$")))
                .WithMessage(ValidationErrorMessages.UnicodeError);

            RuleFor(m => m.PersonalNumber)
                .NotEmpty()
                .Length(11, 11)
                .Matches("^[0-9]*$");

            RuleFor(m => m.BirthDate)
                .NotEmpty()
                .Must(b => DateTimeExtention.IsAdult(b)).WithMessage("Person is under 18")
                .WithMessage(ValidationErrorMessages.IsNotAdult);

            RuleFor(m => m.Gender)
                .NotEmpty();
            RuleFor(m => m.CityId)
                .NotEmpty()
                .MustAsync((s, t) => CityExists(s))
                .WithMessage(ValidationErrorMessages.CityDoesNotExists);
        }

        private async Task<bool> CityExists(int id)
        {
            return await _unitOfWork.CityRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
        }
    }
}
