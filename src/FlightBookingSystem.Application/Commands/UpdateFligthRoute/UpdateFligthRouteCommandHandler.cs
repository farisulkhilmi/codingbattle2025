using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Application.Commands.UpdateFlightRoute;
using MediatR;

namespace FlightBookingSystem.Application.Commands.UpdateFligthRoute
{
    public class UpdateFligthRouteCommandHandler : IRequestHandler<UpdateFligthRouteCommand, Guid>
    {
        private readonly IUnitOfWork _uow;
        private readonly IFlightRouteRepository _flightRouteRepository;
        public UpdateFligthRouteCommandHandler(IUnitOfWork uow, IFlightRouteRepository flightRouteRepository)
        {
            _uow = uow;
            _flightRouteRepository = flightRouteRepository;
        }

        public async Task<Guid> Handle(UpdateFligthRouteCommand request, CancellationToken ct)
        {
            var flightRoute = await _flightRouteRepository.GetFlightRouteByIdAsync(request.Id, ct);
            if (flightRoute != null)
            {
                flightRoute.IsDeparted = request.IsDeparted;
                flightRoute.UpdatedAt = DateTime.UtcNow;
                try
                {
                    await _flightRouteRepository.UpdateFlightRoute(request, ct);
                    await _uow.SaveChangesAsync(ct);
                    return request.Id;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    return Guid.Empty;
                }
            }
            else
            {
                return Guid.Empty;
            }
        }
    }
}
