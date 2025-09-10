using FlightBookingSystem.Application.Abstractions;
using FlightBookingSystem.Domain.Entities;
using MediatR;

namespace FlightBookingSystem.Application.Commands.CreateDestination
{
    public class CreateDestinationCommandHandler : IRequestHandler<CreateDestinationCommand, Guid>
    {
        private readonly IDestinationRepository _repo;
        private readonly IUnitOfWork _uow;

        public CreateDestinationCommandHandler(IDestinationRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }
        public async Task<Guid> Handle(CreateDestinationCommand request, CancellationToken cancellationToken)
        {
            var destination = new Destination
            {
                Name = request.Name,
                DestinationCode = request.DestinationCode,
                CreatedAt = DateTime.UtcNow
            };


            var isExist = await _repo.FindByName(request.Name, cancellationToken);
            if (isExist.Count() > 0)
            {
                return Guid.Empty;
            }

            await _repo.AddAsync(destination, cancellationToken);
            await _uow.SaveChangesAsync(cancellationToken);

            return destination.Id;
        }
    }
}
