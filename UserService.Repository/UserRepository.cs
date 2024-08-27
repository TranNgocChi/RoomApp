using UserService.Database;
using UserService.Repository.Intention;

namespace UserService.Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
}
