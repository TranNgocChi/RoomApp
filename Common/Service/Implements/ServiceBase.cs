using Common.Repository;

namespace Common.Service;

public class ServiceBase<T>(IRepositoryBase<T> repository) : IServiceBase<T> where T : class
{
    public virtual async Task<List<T>> GetAllAsync() => await repository.GetAllAsync();
    public virtual async Task<T?> GetByIdAsync(Guid id) => await repository.GetByIdAsync(id);
    public virtual async Task<T?> CreateAsync(T entity) => await repository.CreateAsync(entity);
    public virtual async Task<OperationResult> UpdateAsync(T entity) => await repository.UpdateAsync(entity);
    public virtual async Task<OperationResult> DeleteAsync(T entity) => await repository.DeleteAsync(entity);
}
