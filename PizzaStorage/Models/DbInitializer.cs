using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStorage.Models
{
    public class DbInitializer
    {
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<IngredientDbContext>());
            }
        }

        public static void SeedData(IngredientDbContext context)
        {
            Console.WriteLine("Applying migrations...");
            context.Database.Migrate();

            if (!context.Ingredients.Any())
            {
                Console.WriteLine("Seeding data");
                context.Ingredients.AddRange(
                    new Ingredient { Name = "Skinka", Price = 10, AmountInStock = 10 },
                    new Ingredient { Name = "Ananas", Price = 10, AmountInStock = 10 },
                    new Ingredient { Name = "Champinjoner", Price = 10, AmountInStock = 10 },
                    new Ingredient { Name = "Lök", Price = 10, AmountInStock = 10 },
                    new Ingredient { Name = "Kebabsås", Price = 10, AmountInStock = 10 },
                    new Ingredient { Name = "Räkor", Price = 15, AmountInStock = 10 },
                    new Ingredient { Name = "Musslor", Price = 15, AmountInStock = 10 },
                    new Ingredient { Name = "Kronärtskocka", Price = 15, AmountInStock = 10 },
                    new Ingredient { Name = "Kebab", Price = 20, AmountInStock = 10 },
                    new Ingredient { Name = "Koriander", Price = 20, AmountInStock = 10 }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Database already contains data. Will not seed.");
            }
        }
    }
}
