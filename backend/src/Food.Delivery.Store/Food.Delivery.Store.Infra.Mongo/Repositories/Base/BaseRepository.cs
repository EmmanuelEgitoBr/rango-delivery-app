using Food.Delivery.Store.Domain.Contracts.Base;
using Food.Delivery.Store.Domain.Entities.Base;
using MongoDB.Driver;

namespace Food.Delivery.Store.Infra.Mongo.Repositories.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly IMongoCollection<T> _collection;

    public BaseRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<T>(collectionName);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task InsertAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(Guid id, T entity)
    {
        await _collection.ReplaceOneAsync(x => x.Id == id, entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
