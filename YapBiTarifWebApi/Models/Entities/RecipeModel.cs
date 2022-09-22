using System.ComponentModel.DataAnnotations;
using YapBiTarifWebApi.Models.Enums;

namespace YapBiTarifWebApi.Models
{
    public class RecipeModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public RecipeTypeEnum? Type { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<RecipeStepModel>? Steps { get; set; }
        public string[]? VisualLinks { get; set; }
        public List<IngredientModel>? Ingredients { get; set; }
        public string[]? Tags { get; set; }
    }
}
