using YapBiTarifWebApi.Helpers;
using YapBiTarifWebApi.Models;

public class IngredientRepository : GenericRepository<IngredientModel>, IIngredientRepository
{
    public IngredientRepository(DataContext context) : base(context) { }
}
