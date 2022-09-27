using Microsoft.EntityFrameworkCore;
using YapBiTarifWebApi.Models;

namespace YapBiTarifWebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions)
            : base(options: dbContextOptions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<AccountTypeModel> AccountTypes { get; set; }
        public DbSet<IngredientModel> Ingredients { get; set; }
        public DbSet<RecipeModel> Recipes { get; set; }
        public DbSet<RecipeTypeModel> RecipeTypes { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
