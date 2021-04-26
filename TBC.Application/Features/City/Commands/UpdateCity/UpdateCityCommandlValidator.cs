using System.Threading.Tasks;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.City.Commands.UpdateCity
{
    public class UpdateCityCommandlValidator : AbstractValidator<UpdateCityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCityCommandlValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(s => s.Id)
                .NotEmpty();
            RuleFor(m => m.Name)
                .NotEmpty()
                .MustAsync((s, t, r) => CityDoesNotExists(s.Id))
                .WithMessage(ValidationErrorMessages.CityDoesNotExists)
                .MustAsync((s, t, r) => CityAlreadyExists(s.Id, s.Name))
                .WithMessage(ValidationErrorMessages.CityAlreadyExists);

        }

        private async Task<bool> CityAlreadyExists(int id, string name)
        {
            if (await CityDoesNotExists(id))
            {
                var city = await _unitOfWork.CityRepository.GetSingleAsync(x =>
                    x.Name.Trim().ToLower() == name.Trim().ToLower() && !x.IsDeleted);
                if (city != null)
                {
                    return city.Id == id;
                }
            }

            return true;
        }
        private async Task<bool> CityDoesNotExists(int id)
        {
            var city = await _unitOfWork.CityRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return city;
        }
    }
}
