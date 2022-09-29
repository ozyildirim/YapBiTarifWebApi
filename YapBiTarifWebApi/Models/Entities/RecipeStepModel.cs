using System.ComponentModel.DataAnnotations.Schema;

public class RecipeStepModel
{
    [Column("id")]
    public int Id { get; set; }

    [Column("value", TypeName = "jsonb")]
    public string? Value { get; set; }
}
