using System.Threading.Tasks;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.RelationshipType.Commands.DeleteRelationshipType
{
    public class DeleteRelationshipTypeCommandlValidator : AbstractValidator<DeleteRelationshipTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteRelationshipTypeCommandlValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(s => s.Id)
                .NotEmpty()
                .MustAsync((s, t, r) => RelationshipTypeDoesNotExists(s.Id))
                .WithMessage(ValidationErrorMessages.RelationshipTypeDoesNotExists);
        }

        private async Task<bool> RelationshipTypeDoesNotExists(int id)
        {
            var ContactType = await _unitOfWork.PersonsRelationshipTypeRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return ContactType;
        }
    }
}
