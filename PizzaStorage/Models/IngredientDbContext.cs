using Microsoft.EntityFrameworkCore;

namespace PizzaStorage.Models
{
    public class IngredientDbContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }

        public IngredientDbContext(DbContextOptions<IngredientDbContext> options)
            : base(options)
        {

        }
    }
}
