using AutoFixture;
using Magic.Words.Core.Models;
using Magic.Words.Core.Repositories;
using Magic.Words.Core.Repository;
using Magic.Words.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MagicTests.ControllerTests {
    public class ShopItemControllerTests {
        private readonly Fixture _fixture;

        public ShopItemControllerTests() {
            _fixture = new Fixture();
        }

        [Fact]
        public void Index_ReturnsViewWithShopItems() {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var shopItems = _fixture.CreateMany<ShopItem>(3).ToList(); // Generate sample ShopItem data
            unitOfWorkMock.Setup(u => u.ShopItemRepository.GetAll(It.IsAny<Expression<Func<ShopItem, bool>>>(), null)).Returns(shopItems);
            var controller = new ShopItemController(unitOfWorkMock.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(shopItems, result.Model); // Check if the returned model matches the expected shopItems
        }
    }
}