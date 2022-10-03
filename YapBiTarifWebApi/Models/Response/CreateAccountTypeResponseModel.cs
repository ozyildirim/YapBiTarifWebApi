using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YapBiTarifWebApi.Models
{
    public class CreateAccountTypeResponseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
