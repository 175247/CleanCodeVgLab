using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
