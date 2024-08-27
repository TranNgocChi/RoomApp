namespace RoomManagement.Database;

public class RoomUser
{
    public Guid Id { get; set; }
    public Guid RoomId { get; set; }
    public Guid UserId { get; set; }
    public Room? Room { get; set; }
}
