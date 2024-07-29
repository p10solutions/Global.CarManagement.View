using Global.CarManagement.View.Domain.Entities;

namespace Global.CarManagement.View.Application.Features.Cars.Queries.GetCar
{
    public class GetCarResponse
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
