using System.Collections.Generic;
using System.Linq;
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

        [Test]
        public void FourDifferentBooks_Gives20PercentDiscount()
        {
            //Arrange
            _basketService = new BasketService();
            var books = new List<Book>
            {
                new Book(1),
                new Book(2),
                new Book(3),
                new Book(4)
            };

            //Act
            var cost = _basketService.CalcCost(books);

            //Assert
            Assert.That(cost, Is.EqualTo(25.60));
        }

        [Test]
        public void FiveDifferentBooks_Gives25PercentDiscount()
        {
            //Arrange
            _basketService = new BasketService();
            var books = new List<Book>
            {
                new Book(1),
                new Book(2),
                new Book(3),
                new Book(4),
                new Book(5)
            };

            //Act
            var cost = _basketService.CalcCost(books);

            //Assert
            Assert.That(cost, Is.EqualTo(30));
        }

        [Test]
        [TestCase(new[] { 1, 1, 1, 2, 2 }, 38.40)]
        [TestCase(new[] { 1, 1, 2, 2, 3, 3, 4, 5 }, 51.20)]
        public void CalculateSpecificBundles_ReturnsCorrectAmounts(int[] bookIds, double expectedCost)
        {
            //Arrange
            _basketService = new BasketService();
            var books = bookIds.Select(bookId => new Book(bookId)).ToList();

            //Act
            var cost = _basketService.CalcCost(books);

            //Assert
            Assert.That(cost, Is.EqualTo(expectedCost));
        }
    }
}