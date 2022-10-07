using YapBiTarifWebApi.Helpers;
using YapBiTarifWebApi.Models;

namespace YapBiTarifWebApi.Repository.Concrete;

public class RecipeTypeRepository : GenericRepository<RecipeTypeModel>, IRecipeTypeRepository
{
    public RecipeTypeRepository(DataContext context) : base(context) { }
}
