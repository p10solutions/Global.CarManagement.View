using Global.CarManagement.View.Application.Features.Common;
using MediatR;

namespace Global.CarManagement.View.Application.Features.Cars.Queries.GetCar
{
    public class GetCarQuery : CommandBase<GetCarQuery>, IRequest<IEnumerable<GetCarResponse>>
    {
        public GetCarQuery() : base(new GetCarQueryValidator())
        {
        }
    }
}
