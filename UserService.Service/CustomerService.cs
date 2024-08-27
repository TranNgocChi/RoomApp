using UserService.Common;
using UserService.Database;
using UserService.Repository.Intention;
using UserService.Service.Intention;

namespace UserService.Service;

public class CustomerService(IUserRepository userRepository) : ICustomerService
{
    public Task<List<User>> GetAllAsync() => userRepository.GetAllAsync();
    public Task<User?> GetByIdAsync(Guid id) => userRepository.GetByIdAsync(id);
    public Task<User?> CreateAsync(User entity)
    {
        entity.Id = Guid.NewGuid();
        return userRepository.CreateAsync(entity);
    }
    public Task<OperationResult> UpdateAsync(User entity) => userRepository.UpdateAsync(entity);
    public Task<OperationResult> DeleteAsync(User entity) => userRepository.DeleteAsync(entity);
}
