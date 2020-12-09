using CleanCodeLab3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanCodeLab3Test
{
    [TestClass]
    public class CleanCodeLab3Test
    {
        private Menu _menuInstance = Menu.Instance;

        [TestMethod]
        public void menu_instance_should_contain_item_instances()
        {
            // Arrange
            // Act
            _menuInstance = Menu.Instance;
            // Assert
            Assert.IsNotNull(_menuInstance);
            Assert.IsNotNull(_menuInstance.PizzaMenu);
            Assert.IsNotNull(_menuInstance.DrinksMenu);
            Assert.IsNotNull(_menuInstance.ExtraIngredientsTenCrowns);
            Assert.IsNotNull(_menuInstance.ExtraIngredientsFifteenCrowns);
            Assert.IsNotNull(_menuInstance.ExtraIngredientsTwentyCrowns);
            _menuInstance = null;
        }

        [TestMethod]
        public void menu_instance_items_can_be_edited()
        {
            // Arrange
            // Act
            _menuInstance = Menu.Instance;
            var countBeforeAddingTestPizza = _menuInstance.PizzaMenu.Count;
            _menuInstance.PizzaMenu.Add(new FoodsAndDrinks
            {
                Name = "Test",
            });
            var countAfterAddingTestPizza = _menuInstance.PizzaMenu.Count;
            // Assert
            Assert.IsTrue(countAfterAddingTestPizza == countBeforeAddingTestPizza + 1);
            _menuInstance = null;
        }

        [TestMethod]
        public void menu_instance_should_contain_items_with_correct_count()
        {
            // Arrange
            _menuInstance = Menu.Instance;
            // Act
            // Assert
            Assert.IsTrue(_menuInstance.PizzaMenu.Count == 5);
            Assert.IsTrue(_menuInstance.DrinksMenu.Count == 3);
            Assert.IsTrue(_menuInstance.ExtraIngredientsTenCrowns.Count == 5);
            Assert.IsTrue(_menuInstance.ExtraIngredientsFifteenCrowns.Count == 3);
            Assert.IsTrue(_menuInstance.ExtraIngredientsTwentyCrowns.Count == 2);
            _menuInstance = null;
        }
    }
}