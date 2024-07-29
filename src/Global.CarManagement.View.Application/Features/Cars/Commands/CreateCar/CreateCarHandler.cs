using AutoMapper;
using Global.CarManagement.View.Domain.Contracts.Data.Repositories;
using Global.CarManagement.View.Domain.Contracts.Notifications;
using Global.CarManagement.View.Domain.Entities;
using Global.CarManagement.View.Domain.Models.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Global.CarManagement.View.Application.Features.Cars.Commands.CreateCar
{
    public class CreateCarHandler : IRequestHandler<CreateCarCommand, CreateCarResponse>
    {
        readonly ICarRepository _CarRepository;
        readonly ILogger<CreateCarHandler> _logger;
        readonly IMapper _mapper;
        readonly INotificationsHandler _notificationsHandler;

        public CreateCarHandler(ICarRepository CarRepository, ILogger<CreateCarHandler> logger,
            IMapper mapper, INotificationsHandler notificationsHandler)
        {
            _CarRepository = CarRepository;
            _logger = logger;
            _mapper = mapper;
            _notificationsHandler = notificationsHandler;
        }

        public async Task<CreateCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var Car = _mapper.Map<CarEntity>(request);

            try
            {
                await _CarRepository.AddAsync(Car);
                var response = _mapper.Map<CreateCarResponse>(Car);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred when trying to insert the Car: {Exception}", ex.Message);

                return _notificationsHandler
                     .AddNotification("An error occurred when trying to insert the Car", ENotificationType.InternalError)
                     .ReturnDefault<CreateCarResponse>();
            }
        }
    }
}
