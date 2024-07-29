using Global.CarManagement.View.Application.Features.Common;
using Global.CarManagement.View.Domain.Entities;
using MediatR;

namespace Global.CarManagement.View.Application.Features.Cars.Commands.CreateCar
{
    public class CreateCarCommand : CommandBase<CreateCarCommand>, IRequest<CreateCarResponse>
    {
        public CreateCarCommand(string name, string details, double price, EStatus status, Guid brandId, Guid photoId) 
            : base(new CreateCarCommandValidator())
        {
        }

        public CreateCarCommand() : base(new CreateCarCommandValidator())
        {
            
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public EStatus Status { get; set; }
        public Guid BrandId { get; set; }
        public Guid PhotoId { get; set; }


    }
}
