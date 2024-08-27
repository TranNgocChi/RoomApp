using RoomManagement.Database;
using RoomManagement.Repository;

namespace RoomManagement.Service;

public class RoomService(IRoomRepository repository) : ServiceBase<Room>(repository), IRoomService
{
}
