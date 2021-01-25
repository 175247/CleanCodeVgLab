using PizzaStorage.Models;

namespace PizzaStorage.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IngredientDbContext _context;
        public IIngredientRepository Ingredients { get; private set; }

        public UnitOfWork(IngredientDbContext context)
        {
            _context = context;
            Ingredients = new IngredientRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
