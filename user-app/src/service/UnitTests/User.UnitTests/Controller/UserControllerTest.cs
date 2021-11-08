using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using User.Api;
using User.Api.Core.Interface;
using User.UnitTests.Setup;
using Xunit;

namespace User.UnitTests
{
    public class UserControllerTest
    {
        private readonly UserController _controller;
        private readonly IUserService _service;
        private readonly ILogger<UserControllerTest> _logger;

        public UserControllerTest()
        {
            _service = new UserServiceFake();
            
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get(3);

            // Assert
            var items = Assert.IsType<List<User.Api.User>>(okResult);
            Assert.Equal(1, items.Count);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetList(0,25);

            // Assert
            var items = Assert.IsType<List<User.Api.User>>(okResult);
            Assert.Equal(3, items.Count);
        }
    }
}
