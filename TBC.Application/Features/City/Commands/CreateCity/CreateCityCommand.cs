using MediatR;

namespace TBC.Application.Features.City.Commands.CreateCity
{
    public class CreateCityCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
