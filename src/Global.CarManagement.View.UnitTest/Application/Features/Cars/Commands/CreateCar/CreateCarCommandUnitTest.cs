using AutoFixture;
using Global.CarManagement.View.Application.Features.Cars.Commands.CreateCar;
using Global.CarManagement.View.Domain.Entities;

namespace Global.CarManagement.UnitTest.Application.Features.Cars.Commands.CreateCar
{
    public class CreateCarCommandUnitTest
    {
        readonly Fixture _fixture;

        public CreateCarCommandUnitTest()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Command_Should_Be_Valid()
        {
            _fixture.Create<CreateCarCommand>();

            var command = _fixture.Create<CreateCarCommand>();

            var result = command.Validate();

            Assert.True(result);
        }

        [Fact]
        public void Command_Should_Be_Invalid()
        {
            EStatus status = EStatus.Active;

            var command = new CreateCarCommand(
                "",
                "572358",
                2023,
                status,
                Guid.Empty,
                Guid.Empty
            );

            var result = command.Validate();

            Assert.False(result);
        }
    }
}
