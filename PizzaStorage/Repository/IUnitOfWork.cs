using System;

namespace PizzaStorage.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IIngredientRepository Ingredients { get; }
        int Complete();
    }
}
