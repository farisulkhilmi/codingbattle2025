using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Domain.Entities;
using MediatR;

namespace FlightBookingSystem.Application.Commands.CreateAircraft
{
    public class CreateAircraftCommandHandler : IRequestHandler<CreateAircraftCommand, Guid>
    {
        private readonly IAircraftRepository _repo;
        private readonly IUnitOfWork _uow;

        public CreateAircraftCommandHandler(IAircraftRepository repo, IUnitOfWork uow)
        { 
            _repo = repo; 
            _uow = uow; 
        }

        public async Task<Guid> Handle(CreateAircraftCommand request, CancellationToken cancellationToken)
        {
            var aircraft = new Aircraft
            {
                Name = request.Name,
                SeatCapacity = request.SeatCapacity,
                CreatedAt = DateTime.UtcNow
            };

            // check if an aircraft with the same name already exists
            var existingAircraft = await _repo.GetAircraftByNameAsync(request.Name.ToLower(), cancellationToken);
            if (existingAircraft != null)
            {
                return Guid.Empty;
            }

            await _repo.AddAsync(aircraft, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return aircraft.Id;
        }
    }
}
