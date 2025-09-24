using Food.Delivery.Store.Domain.Entities.Base;

namespace Food.Delivery.Store.Domain.Contracts.Base;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();
    Task InsertAsync(T entity);
    Task UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);
}
