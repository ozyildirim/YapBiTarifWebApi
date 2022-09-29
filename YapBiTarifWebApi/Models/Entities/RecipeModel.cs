using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YapBiTarifWebApi.Models.Enums;

namespace YapBiTarifWebApi.Models
{
    public class RecipeModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("type")]
        public RecipeTypeEnum? Type { get; set; }

        [Column("authorId")]
        public int? AuthorId { get; set; }

        [Column("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [Column("updatedDate")]
        public DateTime? UpdatedDate { get; set; }

        [Column("steps")]
        public List<RecipeStepModel>? Steps { get; set; }

        [Column("visualLinks")]
        public string[]? VisualLinks { get; set; }

        [Column("ingredients")]
        public List<IngredientModel>? Ingredients { get; set; }

        [Column("tags")]
        public string[]? Tags { get; set; }
    }
}
