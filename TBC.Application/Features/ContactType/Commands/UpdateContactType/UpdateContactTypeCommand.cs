using MediatR;

namespace TBC.Application.Features.ContactType.Commands.UpdateContactType
{
    public class UpdateContactTypeCommand : IRequest
    {
        public int Id  { get; set; }
        public string Name { get; set; }
    }
}
