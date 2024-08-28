namespace Common.Service;

public interface IServiceBase<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> CreateAsync(T entity);
    Task<OperationResult> UpdateAsync(T entity);
    Task<OperationResult> DeleteAsync(T entity);
}
