using System.Threading.Tasks;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.City.Commands.DeleteCity
{
    public class DeleteCityCommandlValidator : AbstractValidator<DeleteCityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCityCommandlValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(s => s.Id)
                .NotEmpty()
                .MustAsync((s, t, r) => CityDoesNotExists(s.Id))
                .WithMessage(ValidationErrorMessages.CityDoesNotExists);
        }

        private async Task<bool> CityDoesNotExists(int id)
        {
            var city = await _unitOfWork.CityRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return city;
        }
    }
}
