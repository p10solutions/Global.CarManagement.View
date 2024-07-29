using AutoFixture;
using AutoMapper;
using Global.CarManagement.View.Application.Features.Cars.Queries.GetCar;
using Global.CarManagement.View.Domain.Contracts.Data.Repositories;
using Global.CarManagement.View.Domain.Contracts.Notifications;
using Global.CarManagement.View.Domain.Entities;
using Global.CarManagement.View.Domain.Models.Notifications;
using Microsoft.Extensions.Logging;
using Moq;

namespace Global.CarManagement.UnitTest.Application.Features.Cars.Queries.GetById
{
    public class GetCarUnitTest
    {
        readonly Mock<ICarRepository> _CarRepository;
        readonly Mock<ILogger<GetCarHandler>> _logger;
        readonly Mock<INotificationsHandler> _notificationsHandler;
        readonly Fixture _fixture;
        readonly GetCarHandler _handler;
        public GetCarUnitTest()
        {
            _CarRepository = new Mock<ICarRepository>();
            _logger = new Mock<ILogger<GetCarHandler>>();
            _notificationsHandler = new Mock<INotificationsHandler>();
            _fixture = new Fixture();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GetCarMapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            _handler = new GetCarHandler(_CarRepository.Object, _logger.Object, 
                _notificationsHandler.Object, mapper);
        }

        [Fact]
        public async Task Car_Should_Be_Geted_Successfully_When_All_Information_Has_Been_Submitted()
        {
            var CarQuery = _fixture.Create<GetCarQuery>();
            var cars = _fixture.CreateMany<CarEntity>();

            _CarRepository.Setup(x => x.GetAsync()).ReturnsAsync(cars);

            var response = await _handler.Handle(CarQuery, CancellationToken.None);

            Assert.NotNull(response);
            _CarRepository.Verify(x => x.GetAsync(), Times.Once);
        }


        [Fact]
        public async Task Car_Should_Not_Be_Geted_When_An_Exception_Was_Thrown()
        {
            var CarQuery = _fixture.Create<GetCarQuery>();
            _CarRepository.Setup(x => x.GetAsync()).Throws(new Exception());
            _notificationsHandler
                .Setup(x => x.AddNotification(It.IsAny<string>(), It.IsAny<ENotificationType>(), It.IsAny<object>()))
                    .Returns(_notificationsHandler.Object);

            var response = await _handler.Handle(CarQuery, CancellationToken.None);

            Assert.Empty(response);
            _CarRepository.Verify(x => x.GetAsync(), Times.Once);
        }
    }
}
