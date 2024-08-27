using UserService.Common;
using UserService.Database;

namespace UserService.Service.Intention;

public interface IRoleService
{
    Task<List<Role>> GetAllAsync();
    Task<Role?> GetByIdAsync(Guid id);
    Task<Role?> CreateAsync(Role entity);
    Task<OperationResult> UpdateAsync(Role entity);
    Task<OperationResult> DeleteAsync(Role entity);
}
