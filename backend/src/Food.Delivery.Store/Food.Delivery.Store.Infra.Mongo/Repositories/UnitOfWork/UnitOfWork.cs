using Food.Delivery.Store.Domain.Contracts.Base;
using Food.Delivery.Store.Domain.Contracts.UnitOfWork;
using Food.Delivery.Store.Domain.Entities.Base;
using Food.Delivery.Store.Infra.Mongo.Repositories.Base;
using MongoDB.Driver;

namespace Food.Delivery.Store.Infra.Mongo.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly IMongoDatabase _database;
    private readonly IMongoClient _client;
    private IClientSessionHandle? _session;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(IMongoClient client, IMongoDatabase database)
    {
        _client = client;
        _database = database;
    }

    public IBaseRepository<T> Repository<T>() where T : BaseEntity
    {
        if (_repositories.ContainsKey(typeof(T)))
            return (IBaseRepository<T>)_repositories[typeof(T)];

        var repo = new BaseRepository<T>(_database, _session);
        _repositories.Add(typeof(T), repo);
        return repo;
    }

    public async Task BeginTransactionAsync()
    {
        if (_session == null)
            _session = await _client.StartSessionAsync();

        _session.StartTransaction();

        // Atualizar todos os repositórios já criados para usarem a sessão
        foreach (var type in _repositories.Keys.ToList())
        {
            var repoType = typeof(BaseRepository<>).MakeGenericType(type);
            var repo = Activator.CreateInstance(repoType, _database, _session);
            _repositories[type] = repo!;
        }
    }

    public async Task CommitTransactionAsync()
    {
        if (_session != null && _session.IsInTransaction)
            await _session.CommitTransactionAsync();
    }

    public async Task AbortTransactionAsync()
    {
        if (_session != null && _session.IsInTransaction)
            await _session.AbortTransactionAsync();
    }

    public void Dispose()
    {
        _session?.Dispose();
    }
}
