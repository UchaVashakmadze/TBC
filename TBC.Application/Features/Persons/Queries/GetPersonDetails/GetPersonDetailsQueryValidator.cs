using System.Threading.Tasks;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsQueryValidator : AbstractValidator<GetPersonDetailsQuery>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPersonDetailsQueryValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(m => m.Id)
                .NotEmpty()
                .MustAsync((s, t, r) => PersonDoesNotExists(s.Id))
                .WithMessage(ValidationErrorMessages.PersonDoesNotExists);
        }

        private async Task<bool> PersonDoesNotExists(int id)
        {
            var person = await _unitOfWork.PersonRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return person;
        }
    }
}
