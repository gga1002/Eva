using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using Eva.Controllers;
using Eva.Core.Models;
using FluentAssertions;
using Eva.Application;
using Eva.Tests.Controllers.Extensions;
using Moq;

namespace Eva.Tests.Controllers.Api
{
    [TestClass]
    public class BookControllerTests
    {
        private BooksController _controller;
        private Mock<IBookService> _mockBookService;
        private string _userId;

        [TestInitialize]
        public void TestInitialize()
        {
            _userId = "1";
            _mockBookService = new Mock<IBookService>();
            _controller = new BooksController(_mockBookService.Object);
            _controller.MockCurrentUser(_userId, "user@mail.com");
        }

        [TestMethod]
        public void Add_BookDataIsNotComplpete_ShouldReturnBadRequest()
        {
            //Arrange
            Book book = null;

            //Act
            var result = _controller.Add(book);

            //Assert
            result.Should().BeOfType<BadRequestResult>();
        }

        [TestMethod]
        public void Add_ValidRequest_ShouldReturnOk()
        {
            //Arrange
            var book = new Book{ Name = "Pedro Paramo"};

            //Act
            var result = _controller.Add(book);

            //Assert
            result.Should().BeOfType<OkResult>();
        }


        [TestMethod]
        public void Update_ValidRequest_ShouldReturnOk()
        {
            //Arrange
            var book = new Book { Name = "Pedro Paramo", ISBN = "213NKKN2" };

            //Act
            var result = _controller.Update(book);

            //Assert
            result.Should().BeOfType<OkResult>();
        }

        [TestMethod]
        public void Remove_ValidRequest_ShouldReturnOk()
        {
            //arrange

            //act
            var result = _controller.Remove(1);

            //Assert
            result.Should().BeOfType<OkResult>();
        }


        [TestMethod]
        public void Get_ValidRequest_ShouldReturnOk()
        {
            //Arrange
            var book = new Book { Name = "Le Petit Prince" };
            var bookTwo = new Book { Name = "Les Miserable" };
            List<Book> books = new List<Book>
            {
                book, bookTwo
            };
            _mockBookService.Setup(s => s.Get(null, null)).Returns(books);

            //Act
            var result = _controller.Get();
            var type = result.GetType();
            //Assert
            result.Should().BeOfType<OkNegotiatedContentResult<IEnumerable<Book>>>();
        }

        [TestMethod]
        public void Get_NoResults_ShouldReturnNotFound()
        {
            //Arrange

            //Act
            var result = _controller.Get();
            var type = result.GetType();
            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
