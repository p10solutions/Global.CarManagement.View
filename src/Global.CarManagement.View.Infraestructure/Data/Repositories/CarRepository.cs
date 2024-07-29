using Global.CarManagement.View.Domain.Contracts.Data.Repositories;
using Global.CarManagement.View.Domain.Entities;
using Global.CarManagement.View.Domain.Models.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Global.CarManagement.View.Infraestructure.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        readonly IMongoCollection<CarEntity> _carCollection;

        public CarRepository(IOptions<MongoDbSettings> settings)
        {
            var mongoSettings = settings.Value;
            var client = new MongoClient(mongoSettings.ConnectionString);
            var database = client.GetDatabase(mongoSettings.DatabaseName);
            _carCollection = database.GetCollection<CarEntity>(mongoSettings.CollectionName);
        }

        public async Task AddAsync(CarEntity Car)
            => await _carCollection.InsertOneAsync(Car);

        public async Task<CarEntity?> GetAsync(Guid id)
            => await _carCollection.Find(moto => moto.Id == id).FirstOrDefaultAsync();
        
        public async Task<IEnumerable<CarEntity>> GetAsync()
            => await _carCollection.Find(_ => true).ToListAsync();
    }
}
