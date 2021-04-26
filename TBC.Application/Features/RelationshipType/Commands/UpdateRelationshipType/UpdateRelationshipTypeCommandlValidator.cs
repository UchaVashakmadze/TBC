using System.Threading.Tasks;
using FluentValidation;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.RelationshipType.Commands.UpdateRelationshipType
{
    public class UpdateRelationshipTypeCommandlValidator : AbstractValidator<UpdateRelationshipTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateRelationshipTypeCommandlValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(s => s.Id)
                .NotEmpty();
            RuleFor(m => m.Name)
                .NotEmpty()
                .MustAsync((s, t, r) => RelationshipTypeDoesNotExists(s.Id))
                .WithMessage(ValidationErrorMessages.RelationshipTypeDoesNotExists)
                .MustAsync((s, t, r) => RelationshipTypeAlreadyExists(s.Id, s.Name))
                .WithMessage(ValidationErrorMessages.RelationshipTypeAlreadyExists);

        }

        private async Task<bool> RelationshipTypeAlreadyExists(int id, string name)
        {
            if (await RelationshipTypeDoesNotExists(id))
            {
                var ContactType = await _unitOfWork.PersonsRelationshipTypeRepository.GetSingleAsync(x =>
                    x.Name.Trim().ToLower() == name.Trim().ToLower() && !x.IsDeleted);
                if (ContactType != null)
                {
                    return ContactType.Id == id;
                }
            }

            return true;
        }
        private async Task<bool> RelationshipTypeDoesNotExists(int id)
        {
            var ContactType = await _unitOfWork.PersonsRelationshipTypeRepository.AnyAsync(x => x.Id == id && !x.IsDeleted);
            return ContactType;
        }
    }
}
