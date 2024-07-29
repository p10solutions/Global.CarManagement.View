using AutoFixture;
using AutoMapper;
using Global.CarManagement.View.Application.Features.Cars.Commands.CreateCar;
using Global.CarManagement.View.Domain.Contracts.Data.Repositories;
using Global.CarManagement.View.Domain.Contracts.Notifications;
using Global.CarManagement.View.Domain.Entities;
using Global.CarManagement.View.Domain.Models.Notifications;
using Microsoft.Extensions.Logging;
using Moq;

namespace Global.CarManagement.UnitTest.Application.Features.Cars.Commands.CreateCar
{
    public class CreateCarHandlerUnitTest
    {
        readonly Mock<ICarRepository> _CarRepository;
        readonly Mock<ILogger<CreateCarHandler>> _logger;
        readonly Mock<INotificationsHandler> _notificationsHandler;
        readonly Fixture _fixture;
        readonly CreateCarHandler _handler;

        public CreateCarHandlerUnitTest()
        {
            _CarRepository = new Mock<ICarRepository>();
            _logger = new Mock<ILogger<CreateCarHandler>>();
            _notificationsHandler = new Mock<INotificationsHandler>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CreateCarMapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            _fixture = new Fixture();
            _handler = new CreateCarHandler(_CarRepository.Object, _logger.Object, mapper,
                _notificationsHandler.Object);
        }

        [Fact]
        public async Task Car_Should_Be_Created_Successfully_When_All_Information_Has_Been_Submitted()
        {
            var CarCommand = _fixture.Create<CreateCarCommand>();

            var response = await _handler.Handle(CarCommand, CancellationToken.None);

            Assert.NotNull(response);
            _CarRepository.Verify(x => x.AddAsync(It.IsAny<CarEntity>()), Times.Once);
        }

        [Fact]
        public async Task Car_Should_Not_Be_Created_When_An_Exception_Was_Thrown()
        {
            var CarCommand = _fixture.Create<CreateCarCommand>();

            _CarRepository.Setup(x => x.AddAsync(It.IsAny<CarEntity>())).Throws(new Exception());
            _notificationsHandler
                .Setup(x => x.AddNotification(It.IsAny<string>(), It.IsAny<ENotificationType>(), It.IsAny<object>()))
                    .Returns(_notificationsHandler.Object);

            var response = await _handler.Handle(CarCommand, CancellationToken.None);

            Assert.Null(response);

            _CarRepository.Verify(x => x.AddAsync(It.IsAny<CarEntity>()), Times.Once);
        }
    }
}
