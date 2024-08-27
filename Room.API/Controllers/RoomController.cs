using Common;
using Microsoft.AspNetCore.Mvc;
using RoomManagement.Database;
using RoomManagement.Service;

namespace RoomManagement.API;

[Route("/rooms")]
[ApiController]
public class RoomController(IRoomService roomService) : ControllerBase
{
    [HttpGet]
    public async Task<List<Room>> GetAll()
    {
        return await roomService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<Room?> GetById(Guid id)
    {
        return await roomService.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<Room?> Create([FromBody] Room room)
    {
        return await roomService.CreateAsync(room);
    }

    [HttpPatch]
    public async Task<OperationResult> Update(Room room)
    {
        return await roomService.UpdateAsync(room);
    }

    [HttpDelete]
    public async Task<OperationResult> Delete(Room room)
    {
        return await roomService.DeleteAsync(room);
    }
}
 