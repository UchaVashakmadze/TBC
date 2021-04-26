using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.City.Commands.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWork.CityRepository.GetSingleAsync(s => s.Id == request.Id && !s.IsDeleted, cancellationToken);
            city.Update(request.Name);

            _unitOfWork.CityRepository.Update(city);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
