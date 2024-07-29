using AutoMapper;
using Global.CarManagement.View.Domain.Entities;

namespace Global.CarManagement.View.Application.Features.Cars.Commands.CreateCar
{
    public class CreateCarMapper: Profile
    {
        public CreateCarMapper()
        {
            CreateMap<CreateCarCommand, CarEntity>();
            CreateMap<CarEntity, CreateCarResponse>();
        }
    }
}
