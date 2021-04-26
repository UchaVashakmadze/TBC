using System.Threading.Tasks;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.RelationshipType.Commands.CreateRelationshipType
{
    public class CreateRelationshipTypeCommandlValidator : AbstractValidator<CreateRelationshipTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateRelationshipTypeCommandlValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(m => m.Name)
                .NotEmpty()
                .MustAsync((s, t) => RelationshipTypeAlreadyExists(s))
                .WithMessage(ValidationErrorMessages.RelationshipTypeAlreadyExists);
        }

        private async Task<bool> RelationshipTypeAlreadyExists(string name)
        {
            var RelationshipType =  await _unitOfWork.PersonsRelationshipTypeRepository.AnyAsync(x => x.Name.Trim().ToLower() == name.Trim().ToLower() && !x.IsDeleted);
            return !RelationshipType;
        }
    }
}
