using Food.Delivery.Store.Domain.Contracts.Base;
using Food.Delivery.Store.Domain.Entities.Base;

namespace Food.Delivery.Store.Domain.Contracts.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<T> Repository<T>() where T : BaseEntity;

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task AbortTransactionAsync();
}
