using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YapBiTarifWebApi.Models.Enums;

namespace YapBiTarifWebApi.Models
{
    public class RecipeModel : BaseEntity
    {
        [Column("name")]
        public string? Name { get; set; }

        [Column("type")]
        public RecipeTypeEnum? Type { get; set; }

        [Column("authorid")]
        public int? AuthorId { get; set; }

        [Column("steps")]
        public List<RecipeStepModel>? Steps { get; set; }

        [Column("visuallinks")]
        public string[]? VisualLinks { get; set; }

        [Column("ingredients")]
        public List<IngredientModel>? Ingredients { get; set; }

        [Column("tags")]
        public string[]? Tags { get; set; }
    }
}
