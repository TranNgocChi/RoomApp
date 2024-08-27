using System.ComponentModel.DataAnnotations;
using UserService.Common;

namespace UserService.Database;

public class Role : EntityCommon
{
    [Required]
    [StringLength(2048)]
    public string? Description { get; set; }
    public IEnumerable<User>? Users { get; set; }
}
