namespace Global.CarManagement.View.Domain.Entities
{
    public class CarEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public EStatus Status { get; set; }
        public Guid BrandId { get; set; }
        public Guid PhotoId { get; set; }

        public CarEntity(Guid id, string name, double price, DateTime createDate, DateTime? updateDate, EStatus status, Guid brandId, Guid photoId)
        {
            Id = id;
            Name = name;
            Price = price;
            CreateDate = createDate;
            UpdateDate = updateDate;
            Status = status;
            BrandId = brandId;
            PhotoId = photoId;
        }
    }
}
