using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserService.Common;
using UserService.Database;
using UserService.Service.Intention;

namespace UserService.API;

[Route("api/roles")]
[ApiController]
public class RoleController(IRoleService roleService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<List<Role>> GetAll()
    {
        return await roleService.GetAllAsync();
    }

    [HttpPost]
    public async Task<Role?> Create(Role user)
    {
        return await roleService.CreateAsync(user);
    }

    [HttpGet("{id}")]
    public async Task<Role?> GetById(Guid id)
    {
        return await roleService.GetByIdAsync(id);
    }

    [HttpPatch]
    public async Task<OperationResult> Update(Role role)
    {
        return await roleService.UpdateAsync(role);
    }

    [HttpDelete]
    public async Task<OperationResult> Delete(Role role)
    {
        return await roleService.DeleteAsync(role);
    }
}
