using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BaseEntity : IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("createdat")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("updatedat")]
    public DateTime UpdatedAt { get; set; }
}
