using System.ComponentModel.DataAnnotations.Schema;

public class RecipeStepModel : BaseEntity
{
    [Column("value", TypeName = "jsonb")]
    public string? Value { get; set; }
}
