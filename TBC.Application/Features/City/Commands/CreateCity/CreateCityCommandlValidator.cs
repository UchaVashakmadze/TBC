using System.Threading.Tasks;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.City.Commands.CreateCity
{
    public class CreateCityCommandlValidator : AbstractValidator<CreateCityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCityCommandlValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(m => m.Name)
                .NotEmpty()
                .MustAsync((s, t) => CityAlreadyExists(s))
                .WithMessage(ValidationErrorMessages.CityAlreadyExists);
        }

        private async Task<bool> CityAlreadyExists(string name)
        {
            var city =  await _unitOfWork.CityRepository.AnyAsync(x => x.Name.Trim().ToLower() == name.Trim().ToLower() && !x.IsDeleted);
            return !city;
        }
    }
}
