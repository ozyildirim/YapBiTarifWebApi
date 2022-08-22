namespace YapBiTarifWebApi.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public AccountTypeModel? AccountType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
