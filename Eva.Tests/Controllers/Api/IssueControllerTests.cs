using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eva.Controllers;
using FluentAssertions;
using Moq;
using Eva.Application;
using System.Web.Http.Results;
using Eva.Tests.Controllers.Extensions;

namespace Eva.Tests.Controllers.Api
{
    [TestClass]
    public class IssueControllerTests
    {
        private IssuesController _controller;
        private Mock<IIssueService> _mockIssueService;
        private object _userId;

        [TestInitialize]
        public void TestInitialize()
        {
            _userId = "1";
            _mockIssueService = new Mock<IIssueService>();
            _controller = new IssuesController(_mockIssueService.Object);
            _controller.MockCurrentUser(_userId, "user@mail.com");
        }

        [TestMethod]
        public void Checkout_ValidRequest_ShouldReturnOk()
        {
            var result = _controller.CheckOut(1);
            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public void CheckIn_ValidRequest_ShouldReturnOk()
        {
            var result = _controller.CheckIn(1);
            result.Should().BeOfType<OkResult>();
        }
    }
}
