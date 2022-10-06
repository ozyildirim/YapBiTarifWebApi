using Microsoft.EntityFrameworkCore;
using YapBiTarifWebApi.Helpers;
using YapBiTarifWebApi.Models;

public class UserRepository : GenericRepository<UserModel>, IUserRepository
{
    public UserRepository(DataContext context) : base(context) { }

    public async Task<string> GetUserName()
    {
        return await GetAll().Select(x => x.Name).FirstOrDefaultAsync();
    }
}
