using YapBiTarifWebApi.Models;

public interface IUserRepository : IRepository<UserModel>
{
    Task<string> GetUserName();
}
