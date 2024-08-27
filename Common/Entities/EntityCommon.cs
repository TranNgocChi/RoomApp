using System.ComponentModel.DataAnnotations;

namespace Common;

public class EntityCommon
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
}
