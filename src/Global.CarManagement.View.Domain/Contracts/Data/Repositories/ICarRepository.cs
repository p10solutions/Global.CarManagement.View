using Global.CarManagement.View.Domain.Entities;

namespace Global.CarManagement.View.Domain.Contracts.Data.Repositories
{
    public interface ICarRepository
    {
        Task AddAsync(CarEntity Car);
        Task<CarEntity?> GetAsync(Guid id);
        Task<IEnumerable<CarEntity>> GetAsync();
    }
}
