using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YapBiTarifWebApi.Models
{
    public class AccountTypeModel : BaseEntity
    {
        [Column("name")]
        public string? Name { get; set; }
    }
}
