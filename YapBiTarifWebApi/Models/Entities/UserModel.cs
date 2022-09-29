using System.ComponentModel.DataAnnotations.Schema;
using YapBiTarifWebApi.Models.Enums;

namespace YapBiTarifWebApi.Models
{
    public class UserModel
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("username")]
        public string? Username { get; set; }

        [Column("password")]
        public string? Password { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("surname")]
        public string? Surname { get; set; }

        [Column("accounttype")]
        public AccountTypeEnum? AccountType { get; set; }

        [Column("createddate")]
        public DateTime? CreatedDate { get; set; }

        [Column("profilepictureurl")]
        public string? ProfilePictureUrl { get; set; }
    }
}
