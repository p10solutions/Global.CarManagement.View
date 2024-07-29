using AutoMapper;
using Global.CarManagement.View.Domain.Models.Events.Cars;

namespace Global.CarManagement.View.Application.Features.Cars.Commands.CreateCar
{
    public class CreatedCarEventMapper : Profile
    {
        public CreatedCarEventMapper()
        {
            CreateMap<CreatedCarEvent, CreateCarCommand>();
        }
    }
}
