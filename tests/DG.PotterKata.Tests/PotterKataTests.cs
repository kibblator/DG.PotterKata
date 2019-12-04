using System.Collections.Generic;
using NUnit.Framework;

namespace DG.PotterKata.Tests
{
    public class Tests
    {
        private Basket _basket;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OneBook_NoDiscount_Costs8Euros()
        {
            //Arrange
            _basket = new Basket();
            var books = new List<Book>
            {
                new Book(1)
            };

            //Act
            var cost = _basket.CalcCost(books);

            //Assert
            Assert.That(cost, Is.EqualTo(8));
        }

        [Test]
        public void TwoSameBooks_Costs16Euros()
        {
            //Arrange
            _basket = new Basket();
            var books = new List<Book>
            {
                new Book(1),
                new Book(1)
            };

            //Act
            var cost = _basket.CalcCost(books);

            //Assert
            Assert.That(cost, Is.EqualTo(16));
        }

        [Test]
        public void TwoDifferentBooks_Gives5PercentDiscount()
        {
            //Arrange
            _basket = new Basket();
            var books = new List<Book>
            {
                new Book(1),
                new Book(2)
            };

            //Act
            var cost = _basket.CalcCost(books);

            //Assert
            Assert.That(cost, Is.EqualTo(15.20));
        }
    }
}