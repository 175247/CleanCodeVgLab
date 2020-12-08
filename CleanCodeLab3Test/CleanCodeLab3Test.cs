using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanCodeLab3Test
{
    [TestClass]
    public class CleanCodeLab3Test
    {
        [TestMethod]
        public void menu_instance_should_contain_item_instances()
        {
            // Arrange
            // Act
            _menuInstance.GenerateMenuItems();
            // Assert
            Assert.IsNotNull(_menuInstance);
            Assert.IsNotNull(_menuInstance.PizzaMenu);
            Assert.IsNotNull(_menuInstance.DrinksMenu);
            Assert.IsNotNull(_menuInstance.ExtraIngredientsTenCrowns);
            Assert.IsNotNull(_menuInstance.ExtraIngredientsFifteenCrowns);
            Assert.IsNotNull(_menuInstance.ExtraIngredientsTwentyCrowns);
        }

        [TestMethod]
        public void menu_instance_items_can_be_edited()
        {
            // Arrange
            // Act
            var countBeforeAddingTestPizza = _menuInstance.PizzaMenu.Count;
            _menuInstance.PizzaMenu.Add(new FoodsAndDrinks
            {
                Name = "Test",
            });
            var countAfterAddingTestPizza = _menuInstance.PizzaMenu.Count;
            // Assert
            Assert.IsTrue(countAfterAddingTestPizza == countBeforeAddingTestPizza + 1);
        }

        [TestMethod]
        public void menu_instance_should_contain_items_with_correct_count()
        {
            // Arrange
            var menuInstance = Menu.Instance;
            // Act
            // Assert
            // To avoid test order descrepencies.
            Assert.IsTrue(menuInstance.PizzaMenu.Count == 4 || menuInstance.PizzaMenu.Count == 5);
            Assert.IsTrue(menuInstance.DrinksMenu.Count == 3);
            Assert.IsTrue(menuInstance.ExtraIngredientsTenCrowns.Count == 5);
            Assert.IsTrue(menuInstance.ExtraIngredientsFifteenCrowns.Count == 3);
            Assert.IsTrue(menuInstance.ExtraIngredientsTwentyCrowns.Count == 2);
        }
    }
}
