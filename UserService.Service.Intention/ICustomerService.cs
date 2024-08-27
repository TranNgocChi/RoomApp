using UserService.Common;
using UserService.Database;

namespace UserService.Service.Intention;

public interface ICustomerService
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> CreateAsync(User entity);
    Task<OperationResult> UpdateAsync(User entity);
    Task<OperationResult> DeleteAsync(User entity);
}
