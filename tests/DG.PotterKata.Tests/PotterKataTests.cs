using NUnit.Framework;

namespace DG.PotterKata.Tests
{
    public class Tests
    {
        private Basket _basket;

        [SetUp]
        public void Setup()
        {
            _basket = new Basket();
        }

        [Test]
        public void OneBook_NoDiscount_Costs8Euros()
        {
            //Arrange
            var quantity = 1;

            //Act
            var cost = _basket.CalcCost(quantity);

            //Assert
            Assert.That(cost, Is.EqualTo(8));
        }
    }
}