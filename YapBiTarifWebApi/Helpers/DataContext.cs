

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


        public DbSet<AccountTypeModel> AccountTypes { get; set; }
        public DbSet<IngredientModel> Ingredients { get; set; }
        public DbSet<RecipeModel> Recipes { get; set; }
        public DbSet<RecipeTypeModel> RecipeTypes { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
