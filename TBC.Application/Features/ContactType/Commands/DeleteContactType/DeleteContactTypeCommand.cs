using MediatR;

namespace TBC.Application.Features.ContactType.Commands.DeleteContactType
{
    public class DeleteContactTypeCommand : IRequest
    {
        public int Id  { get; set; }
    }
}
