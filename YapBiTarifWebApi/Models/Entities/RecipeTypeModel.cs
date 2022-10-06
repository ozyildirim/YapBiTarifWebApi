using System.ComponentModel.DataAnnotations.Schema;

namespace YapBiTarifWebApi.Models
{
    public class RecipeTypeModel : BaseEntity
    {
        [Column("name")]
        public string? Name { get; set; }
    }
}
