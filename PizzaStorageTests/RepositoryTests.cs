using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzaStorage.Models;
using PizzaStorage.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStorageTests
{
    [TestClass]
    public class RepositoryTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private IEnumerable<Ingredient> ingredients;
        private readonly StorageService _sut;
        private readonly Mock<IIngredientRepository> _ingredientRepositoryMock = new Mock<IIngredientRepository>();

        public RepositoryTests()
        {
            _sut = new StorageService(_unitOfWorkMock.Object);
            ingredients = new List<Ingredient>
            {
                new Ingredient { Id = 90, Name = "Ost", AmountInStock = 100, Price = 0 },
                new Ingredient { Id = 91, Name = "Oliver", AmountInStock = 100, Price = 0 },
                new Ingredient { Id = 92, Name = "Prosciutto", AmountInStock = 100, Price = 0 }
            };

            _unitOfWorkMock.Setup(m => m.Ingredients.GetAllIngredients()).Returns(ingredients);
            _unitOfWorkMock.Setup(m => m.Ingredients.Get(
                It.IsAny<int>()))
                .Returns((int i) => ingredients
                .Where(x => x.Id == i)
                .FirstOrDefault());

            _ingredientRepositoryMock.Setup(m => m.GetAllIngredients()).Returns(ingredients);
            _ingredientRepositoryMock.Setup(m => m.Get(
                It.IsAny<int>()))
                .Returns((int i) => ingredients
                .Where(x => x.Id == i)
                .FirstOrDefault());
        }

        [TestMethod]
        public void getting_ingredient_by_id_should_return_correct_ingredient()
        {
            // Arrange
            var ingredient = new Ingredient { Id = 90, Name = "Ost", Price = 0, AmountInStock = 100 };
            var expected = ingredients.ToList().Where(i => i.Id == 90).FirstOrDefault();


            // Act
            var actual = _sut.GetById(ingredient.Id);

            // Assert
            Assert.AreEqual(expected.Name, actual.Name);
        }

        [TestMethod]
        public void calling_to_reduce_amount_in_storage_should_correctly_reduce_amount_by_one()
        {
            // Arrange
            var ingredient = new Ingredient { Id = 91, Name = "Oliver", AmountInStock = 100, Price = 0 };
            var expected = new Ingredient { Id = 91, Name = "Oliver", AmountInStock = 99, Price = 0 };

            // Act
            _sut.ReduceAmountInStock(ingredient);
            var actual = _sut.GetById(ingredient.Id);

            // Assert
            Assert.AreEqual(expected.AmountInStock, actual.AmountInStock);
        }

        [TestMethod]
        public void receiving_a_mass_delivery_should_increase_stock_of_all_items_by_ten()
        {
            // Arrange
            var expected = new List<Ingredient>
            {
                new Ingredient { Id = 90, Name = "Ost", AmountInStock = 110, Price = 0 },
                new Ingredient { Id = 91, Name = "Oliver", AmountInStock = 110, Price = 0 },
                new Ingredient { Id = 92, Name = "Prosciutto", AmountInStock = 110, Price = 0 }
            };

            // Act
            _sut.ReceiveMassDelivery();
            var actual = _sut.GetAllIngredients().ToList();

            // Assert
            Assert.AreEqual(expected[1].AmountInStock, actual[1].AmountInStock);
        }

        [TestMethod]
        public void restocking_a_single_ingredient_should_increase_its_stored_amount_by_one()
        {
            // Arrange
            var ingredient = new Ingredient { Id = 92, Name = "Prosciutto", AmountInStock = 100, Price = 0 };
            var expected = new Ingredient { Id = 92, Name = "Prosciutto", AmountInStock = 101, Price = 0 };

            // Act
            var actual = _sut.RestockSingleIngredient(ingredient.Id);

            // Assert
            Assert.AreEqual(expected.AmountInStock, actual.AmountInStock);
        }

        [TestMethod]
        public void when_cypress_is_done_with_tests_the_database_should_revert_changes()
        {
            // Arrange
            var ingredient = new Ingredient { Id = 92, Name = "Prosciutto", AmountInStock = 100, Price = 0 };
            var expected = new Ingredient { Id = 92, Name = "Prosciutto", AmountInStock = 100, Price = 0 };

            // Act
            _sut.RestockSingleIngredient(ingredient.Id);
            _sut.ResetTests(ingredient.Name, "addIngredients");

            var actual = _sut.GetById(ingredient.Id);

            // Assert
            Assert.AreEqual(expected.AmountInStock, actual.AmountInStock);
        }

    }
}
