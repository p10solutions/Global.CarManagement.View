using AutoMapper;
using Global.CarManagement.View.Domain.Contracts.Data.Repositories;
using Global.CarManagement.View.Domain.Contracts.Notifications;
using Global.CarManagement.View.Domain.Models.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Global.CarManagement.View.Application.Features.Cars.Queries.GetCar
{
    public class GetCarHandler : IRequestHandler<GetCarQuery, IEnumerable<GetCarResponse>>
    {
        readonly ICarRepository _CarRepository;
        readonly ILogger<GetCarHandler> _logger;
        readonly INotificationsHandler _notificationsHandler;
        readonly IMapper _mapper;

        public GetCarHandler(ICarRepository CarRepository, ILogger<GetCarHandler> logger,
            INotificationsHandler notificationsHandler, IMapper mapper)
        {
            _CarRepository = CarRepository;
            _logger = logger;
            _notificationsHandler = notificationsHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCarResponse>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var Car = await _CarRepository.GetAsync();

                var response = _mapper.Map<IEnumerable<GetCarResponse>>(Car);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred when trying to get the Car: {exception}", ex.Message);

                return _notificationsHandler
                        .AddNotification("An error occurred when trying to get the Car", ENotificationType.InternalError)
                        .ReturnDefault<IEnumerable<GetCarResponse>>();
            }
        }
    }
}
