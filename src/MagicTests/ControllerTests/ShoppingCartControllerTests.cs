using Magic.Words.Core.Repositories;
using Magic.Words.Core.ViewModels;
using Magic.Words.Shared.Hubs;
using Magic.Words.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTests.ControllerTests {
    public class ShoppingCartControllerTests {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<ILogger<ShoppingCartController>> _loggerMock;
        private readonly Mock<IHubContext<ChatHub>> _hubContextMock;

        public ShoppingCartControllerTests() {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _loggerMock = new Mock<ILogger<ShoppingCartController>>();
            _hubContextMock = new Mock<IHubContext<ChatHub>>();
        }

        [Fact]
        public void Index_ReturnsViewWithShoppingCartVM() {
            // Arrange
            var controller = new ShoppingCartController(_loggerMock.Object, _unitOfWorkMock.Object, _hubContextMock.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ShoppingCartVM>(result.Model);
        }

        [Fact]
        public void Summary_ReturnsViewWithShoppingCartVM() {
            // Arrange
            var controller = new ShoppingCartController(_loggerMock.Object, _unitOfWorkMock.Object, _hubContextMock.Object);

            // Act
            var result = controller.Summary() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ShoppingCartVM>(result.Model);
        }

        [Fact]
        public async Task Plus_ReturnsRedirectToActionResult() {
            // Arrange
            var controller = new ShoppingCartController(_loggerMock.Object, _unitOfWorkMock.Object, _hubContextMock.Object);

            // Act
            var result = await controller.Plus(1) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        
    }
}