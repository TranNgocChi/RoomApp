using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserService.Common;
using UserService.Database;
using UserService.Service.Intention;

namespace UserService.API;

[Route("api/users")]
[ApiController]
public class UserController(ICustomerService customerService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<List<UserModel>> GetAll()
    {
        var listUser = await customerService.GetAllAsync();
        return mapper.Map<List<UserModel>>(listUser);
    }

    [HttpPost]
    public async Task<UserModel?> Create([FromBody] UserCreationModel userCreation)
    {
        var domain = mapper.Map<User>(userCreation);
        var result = await customerService.CreateAsync(domain);
        return mapper.Map<UserModel>(result);
    }

    [HttpGet("{id}")]
    public async Task<User?> GetById([FromRoute] Guid id)
    {
        return await customerService.GetByIdAsync(id);
    }

    [HttpPatch]
    public async Task<OperationResult> Update([FromBody] UserModel userModel)
    {
        var user = mapper.Map<User>(userModel);
        return await customerService.UpdateAsync(user);
    }

    [HttpDelete]
    public async Task<OperationResult> Delete(User user)
    {
        return await customerService.DeleteAsync(user);
    }
}
