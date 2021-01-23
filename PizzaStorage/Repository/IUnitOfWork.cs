using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStorage.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IIngredientRepository Ingredients { get; }
        int Complete();
    }
}
