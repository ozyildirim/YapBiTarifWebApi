using System.ComponentModel.DataAnnotations.Schema;

namespace YapBiTarifWebApi.Models
{
    public class CreateRecipeTypeResponseModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
