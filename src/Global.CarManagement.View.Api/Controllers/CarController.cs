using Global.CarManagement.View.Api.Controllers.Base;
using Global.CarManagement.View.Application.Features.Cars.Queries.GetCar;
using Global.CarManagement.View.Domain.Contracts.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Global.CarManagement.View.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController(IMediator mediator, INotificationsHandler notifications) : ApiControllerBase(mediator, notifications)
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCarResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync()
            => await SendAsync(new GetCarQuery());
    }
}
