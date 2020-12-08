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
    }
}
