using MediatR;

namespace TBC.Application.Features.ContactType.Commands.CreateContactType
{
    public class CreateContactTypeCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
