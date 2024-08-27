using UserService.Common;
using UserService.Database;
using UserService.Repository.Intention;
using UserService.Service.Intention;

namespace UserService.Service;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    public Task<List<Role>> GetAllAsync() => roleRepository.GetAllAsync();
    public Task<Role?> GetByIdAsync(Guid id) => roleRepository.GetByIdAsync(id);
    public Task<Role?> CreateAsync(Role entity) => roleRepository.CreateAsync(entity);
    public Task<OperationResult> UpdateAsync(Role entity) => roleRepository.UpdateAsync(entity);
    public Task<OperationResult> DeleteAsync(Role entity) => roleRepository.DeleteAsync(entity);
}
