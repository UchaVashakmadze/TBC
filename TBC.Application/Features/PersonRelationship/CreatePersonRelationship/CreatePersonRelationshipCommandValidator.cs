using System.Threading.Tasks;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.PersonRelationship.CreatePersonRelationship
{
    public class CreatePersonRelationshipModelValidator : AbstractValidator<CreatePersonRelationshipCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonRelationshipModelValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(m => m.PersonId)
                .NotEqual(m => m.RelatedPersonId);
            RuleFor(m => m.PersonId)
                .NotEmpty()
                .MustAsync((s, t, r) => PersonDoesNotExists(s.PersonId)).WithMessage(ValidationErrorMessages.PersonDoesNotExists);
            RuleFor(m => m.RelatedPersonId)
                .NotEmpty()
                .MustAsync((s, t, r) => PersonDoesNotExists(s.RelatedPersonId)).WithMessage(ValidationErrorMessages.PersonDoesNotExists);
            RuleFor(m => m.PersonsRelationshipTypeId)
                .NotEmpty()
                .MustAsync((s, t, r) => RelationshipTypeDoesNotExists(s.PersonsRelationshipTypeId)).WithMessage(ValidationErrorMessages.RelationshipTypeDoesNotExists);
        }

        private async Task<bool> PersonDoesNotExists(int id)
        {
            var person = await _unitOfWork.PersonRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return person;
        }

        private async Task<bool> RelationshipTypeDoesNotExists(int id)
        {
            var relationshipType = await _unitOfWork.PersonsRelationshipTypeRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return relationshipType;
        }
    }
}
