using Global.CarManagement.View.Domain.Entities;

namespace Global.CarManagement.View.Application.Features.Cars.Commands.CreateCar
{
    public class CreateCarResponse(Guid id, string name, double price, DateTime createDate, DateTime? updateDate, EStatus status, Guid brandId, Guid photoId)
    {

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
