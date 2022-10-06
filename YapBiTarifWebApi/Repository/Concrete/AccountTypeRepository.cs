using YapBiTarifWebApi.Helpers;
using YapBiTarifWebApi.Models;

public class AccountTypeRepository : GenericRepository<AccountTypeModel>, IAccountTypeRepository
{
    public AccountTypeRepository(DataContext context) : base(context) { }
}
