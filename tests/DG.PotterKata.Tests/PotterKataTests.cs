using System.Collections.Generic;
using DG.PotterKata.Models;
using DG.PotterKata.Services;
using NUnit.Framework;

namespace DG.PotterKata.Tests
{
    public class Tests
    {
        private BasketService _basketService;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OneBook_NoDiscount_Costs8Euros()
        {
            //Arrange
            _basketService = new BasketService();
            var books = new List<Book>
            {
                new Book(1)
            };

            //Act
            var cost = _basketService.CalcCost(books);

            //Assert
            Assert.That(cost, Is.EqualTo(8));
        }

        [Test]
        public void TwoSameBooks_Costs16Euros()
        {
            //Arrange
            _basketService = new BasketService();
            var books = new List<Book>
            {
                new Book(1),
                new Book(1)
            };

            //Act
            var cost = _basketService.CalcCost(books);

            //Assert
            Assert.That(cost, Is.EqualTo(16));
        }

        [Test]
        public void TwoDifferentBooks_Gives5PercentDiscount()
        {
            //Arrange
            _basketService = new BasketService();
            var books = new List<Book>
            {
                new Book(1),
                new Book(2)
            };

            //Act
            var cost = _basketService.CalcCost(books);

            //Assert
            Assert.That(cost, Is.EqualTo(15.20));
        }

        [Test]
        public void ThreeDifferentBooks_Gives10PercentDiscount()
        {
            //Arrange
            _basketService = new BasketService();
            var books = new List<Book>
            {
                new Book(1),
                new Book(2),
                new Book(3)
            };

            //Act
            var cost = _basketService.CalcCost(books);

            //Assert
            Assert.That(cost, Is.EqualTo(21.60));
        }
    }
}