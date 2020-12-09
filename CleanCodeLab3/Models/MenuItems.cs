using System.Collections.Generic;

namespace CleanCodeLab3
{
    public class MenuItems
    {
        public string Name { get; set; }
        public List<MenuItems> Ingredients { get; set; }
        public double Price { get; set; }

        public MenuItems()
        {
        }

        public MenuItems(string name, List<MenuItems> ingredients, double price)
        {
            Name = name;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
