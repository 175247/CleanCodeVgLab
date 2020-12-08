using CleanCodeLab3.Models;
using CleanCodeLab3.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanCodeLab3Test
{
    [TestClass]
    public class CleanCodeLab3Test
    {
        [TestMethod]
        public void pizza_factory_should_return_a_pizza_when_called()
        {
            var pizzaFactory = new PizzaFactory();
            var expected = typeof(Pizza);
            var actual = pizzaFactory.CreateMargerita();

            Assert.AreEqual(expected, actual.GetType());
        }
    }
}
