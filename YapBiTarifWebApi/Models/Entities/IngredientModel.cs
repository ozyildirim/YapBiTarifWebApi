using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YapBiTarifWebApi.Models
{
    public class IngredientModel : BaseEntity
    {
        [Column("name")]
        public string? Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("imagelink")]
        public string? ImageLink { get; set; }
    }
}
