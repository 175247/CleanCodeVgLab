using CleanCodeLab3.Models;

namespace CleanCodeLab3.Interfaces
{
    public interface IDrinkFactory
    {
        public Drink CreateCocaCola();
        public Drink CreateFanta();
        public Drink CreateSprite();
    }
}
