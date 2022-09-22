using System.ComponentModel.DataAnnotations;

namespace YapBiTarifWebApi.Models
{
    public class IngredientModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageLink { get; set; }
    }
}
