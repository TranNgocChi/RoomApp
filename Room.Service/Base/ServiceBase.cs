using Common;
using RoomManagement.Repository;

namespace RoomManagement.Service;

public class ServiceBase<T>(IRepositoryBase<T> repository) : IServiceBase<T> where T : class
{
    public Task<List<T>> GetAllAsync() => repository.GetAllAsync();
    public Task<T?> GetByIdAsync(Guid id) => repository.GetByIdAsync(id);
    public Task<T?> CreateAsync(T entity) => repository.CreateAsync(entity);
    public Task<OperationResult> UpdateAsync(T entity) => repository.UpdateAsync(entity);
    public Task<OperationResult> DeleteAsync(T entity) => repository.DeleteAsync(entity);
}
