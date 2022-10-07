using YapBiTarifWebApi.Helpers;
using YapBiTarifWebApi.Models;

public class RecipeRepository : GenericRepository<RecipeModel>, IRecipeRepository
{
    public RecipeRepository(DataContext context) : base(context) { }
}
