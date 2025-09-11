using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Domain.Entities;
using MediatR;

namespace FlightBookingSystem.Application.Commands.CreateFlightRoute
{
    public class CreateFlightRouteCommandHandler : IRequestHandler<CreateFlightRouteCommand, Guid>
    {
        private readonly IFlightRouteRepository _flightRouterepo;
        private readonly IAircraftRepository _aircraftRepo;
        private readonly IDestinationRepository _destinationRepo;
        private readonly IUnitOfWork _uow;

        public CreateFlightRouteCommandHandler(IFlightRouteRepository flightRouterepo, IAircraftRepository aircraftRepo, IDestinationRepository destinationRepo, IUnitOfWork uow)
        {
            _flightRouterepo = flightRouterepo;
            _aircraftRepo = aircraftRepo;
            _destinationRepo = destinationRepo;
            _uow = uow;
        }

        public async Task<Guid> Handle(CreateFlightRouteCommand request, CancellationToken cancellationToken)
        {
            var origin = await _destinationRepo.GetDestinationByName(request.OriginCity.ToLower(), cancellationToken);
            if (origin == null)
            {
                return Guid.Empty;
            }

            var destination = await _destinationRepo.GetDestinationByName(request.DestinationCity.ToLower(), cancellationToken);
            if (destination == null)
            {
                return Guid.Empty;
            }

            // get the aircraft by name
            var aircraft = await _aircraftRepo.GetAircraftByNameAsync(request.AircraftName.ToLower(), cancellationToken);
            if (aircraft == null)
            {
                return Guid.Empty;
            }

            var fligthNumber = aircraft.Name + "-" + origin.DestinationCode + destination.DestinationCode + "-" + request.ScheduledDay;
            var flightRoute = new FlightRoute
            {
                FlightNumber = fligthNumber,
                OriginId = origin.Id,
                DestinationId = destination.Id,
                AircraftId = aircraft.Id,
                ScheduledDay = request.ScheduledDay,
                SeatAvailibity = aircraft.SeatCapacity,
                CreatedAt = DateTime.UtcNow
            };

            var isExist = await _flightRouterepo.GetFlightRouteByOriginAndDestAsync(origin.Id, destination.Id, request.ScheduledDay, cancellationToken);
            if (isExist != null)
            {
                return Guid.Empty;
            }

            await _flightRouterepo.AddAsync(flightRoute, cancellationToken);

            return flightRoute.Id;
        }
    }
}
