using AutoMapper;
using Global.CarManagement.View.Domain.Entities;

namespace Global.CarManagement.View.Application.Features.Cars.Queries.GetCar
{
    public class GetCarMapper: Profile
    {
        public GetCarMapper()
        {
            CreateMap<CarEntity, GetCarResponse>();
        }
    }
}
