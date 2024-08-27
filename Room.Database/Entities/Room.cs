using Common;
using System.ComponentModel.DataAnnotations;

namespace RoomManagement.Database;

public class Room : EntityCommon
{
    [Required]
    [StringLength(2048)]
    public string? Description { get; set; }

    public ICollection<RoomUser>? RoomUsers {  get; set; }
}
