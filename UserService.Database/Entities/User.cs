using System.ComponentModel.DataAnnotations;
using UserService.Common;

namespace UserService.Database;

public class User : EntityCommon
{
    [EmailAddress]
    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    public IEnumerable<Role>? Roles { get; set; }
}
