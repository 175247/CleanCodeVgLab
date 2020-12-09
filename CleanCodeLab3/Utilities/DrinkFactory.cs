using CleanCodeLab3.Interfaces;
using CleanCodeLab3.Models;

namespace CleanCodeLab3.Utilities
{
    public class DrinkFactory : IDrinkFactory
    {
        public Drink CreateCocaCola()
        {
            return new Drink { Name = "Coca cola", Price = 20 };
        }

        public Drink CreateFanta()
        {
            return new Drink { Name = "Fanta", Price = 20 };
        }

        public Drink CreateSprite()
        {
            return new Drink { Name = "Sprite", Price = 25 };
        }
    }
}
