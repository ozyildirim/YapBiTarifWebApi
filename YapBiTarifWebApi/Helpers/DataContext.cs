

using Microsoft.EntityFrameworkCore;
using YapBiTarifWebApi.Models;

namespace YapBiTarifWebApi.Helpers
{
    public class DataContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }


        public DbSet<AccountTypeModel> AccountTypeModels { get; set; }
        public DbSet<IngredientModel> IngredientModels { get; set; }
        public DbSet<RecipeModel> RecipeModels { get; set; }
        public DbSet<RecipeTypeModel> RecipeTypeModels { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
    }
}
