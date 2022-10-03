using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YapBiTarifWebApi.Models
{
    public class CreateAccountTypeRequestModel
    {
        public string? Name { get; set; }
    }
}
