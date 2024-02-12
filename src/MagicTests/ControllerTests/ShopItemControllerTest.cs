﻿using AutoFixture;
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
    public class SubscriptionControllerTests {
        private readonly Fixture _fixture;

        public SubscriptionControllerTests() {
            _fixture = new Fixture();
        }

        [Fact]
        public void Index_ReturnsViewWithSubscriptions() {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var subscriptions = _fixture.CreateMany<Subscription>(3).ToList(); // Generate sample ShopItem data
            unitOfWorkMock.Setup(u => u.SubscriptionRepository.GetAll(It.IsAny<Expression<Func<Subscription, bool>>>(), null)).Returns(subscriptions);
            var controller = new SubscriptionController(unitOfWorkMock.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(subscriptions, result.Model);  
        }
    }
}