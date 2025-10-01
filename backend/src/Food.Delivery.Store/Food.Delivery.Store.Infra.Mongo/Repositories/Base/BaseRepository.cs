using Food.Delivery.Store.Domain.Contracts.Base;
using Food.Delivery.Store.Domain.Entities.Base;
using MongoDB.Driver;

namespace Food.Delivery.Store.Infra.Mongo.Repositories.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly IMongoCollection<T> _collection;
    private readonly IClientSessionHandle? _session;

    public BaseRepository(IMongoDatabase database,
        IClientSessionHandle? session = null)
    {
        _collection = database.GetCollection<T>(typeof(T).Name);
        _session = session;
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
        if (_session != null)
            await _collection.InsertOneAsync(_session, entity);
        else
            await _collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(Guid id, T entity)
    {
        if (_session != null)
            await _collection.ReplaceOneAsync(_session, x => x.Id == id, entity);
        else
            await _collection.ReplaceOneAsync(x => x.Id == id, entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        if (_session != null)
            await _collection.DeleteOneAsync(_session, x => x.Id == id);
        else
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
