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
    public class SubscriptionmControllerTests {
        private readonly Fixture _fixture;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        public SubscriptionmControllerTests() {
            _fixture = new Fixture();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void Index_ReturnsViewWithSubscriptionms() {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var sunscriptions = _fixture.CreateMany<ShopItem>(3).ToList();  
            unitOfWorkMock.Setup(u => u.ShopItemRepository.GetAll(It.IsAny<Expression<Func<ShopItem, bool>>>(), null)).Returns(sunscriptions);
            var controller = new ShopItemController(unitOfWorkMock.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(sunscriptions, result.Model);  
        }

        [Fact]
        public void Index_ReturnsViewWithSubscriptions() {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var subscriptions = _fixture.CreateMany<Subscription>(3).ToList();  
            unitOfWorkMock.Setup(u => u.SubscriptionRepository.GetAll(It.IsAny<Expression<Func<Subscription, bool>>>(), null)).Returns(subscriptions);
            var controller = new SubscriptionController(unitOfWorkMock.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(subscriptions, result.Model);
        }

        [Fact]
        public void Edit_ValidSubscription_RedirectsToIndex() {
            // Arrange
            var subscription = new Subscription();
            var controller = new SubscriptionController(_unitOfWorkMock.Object);

            // Act
            var result = controller.Edit(subscription) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void Delete_ExistingSubscription_ReturnsViewWithSubscription() {
            // Arrange
            var subscriptionId = 1;
            var subscription = new Subscription { SubscriptionId = subscriptionId };
            _unitOfWorkMock.Setup(u => u.SubscriptionRepository.Get(It.IsAny<Expression<Func<Subscription, bool>>>(), null))
                           .Returns(subscription);
            var controller = new SubscriptionController(_unitOfWorkMock.Object);

            // Act
            var result = controller.Delete(subscriptionId) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(subscription, result.Model);
        }

        [Fact]
        public void DeletePost_ExistingSubscription_RedirectsToIndex() {
            // Arrange
            var subscriptionId = 1;
            var subscription = new Subscription { SubscriptionId = subscriptionId };
            _unitOfWorkMock.Setup(u => u.SubscriptionRepository.Get(It.IsAny<Expression<Func<Subscription, bool>>>(), null)).Returns(subscription);
            var controller = new SubscriptionController(_unitOfWorkMock.Object);

            // Act
            var result = controller.DeletePost(subscriptionId) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }


    }
}