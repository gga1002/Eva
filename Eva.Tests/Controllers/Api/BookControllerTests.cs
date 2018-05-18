using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using Eva.Controllers;
using Eva.Core.Models;
using FluentAssertions;
using Eva.Application;
using Moq;

namespace Eva.Tests.Controllers.Api
{
    [TestClass]
    public class BookControllerTests
    {
        private BookController _controller;
        private Mock<IBookService> _mockBookService;
        [TestInitialize]
        public void TestInitialize()
        {
            _mockBookService = new Mock<IBookService>();
            _controller = new BookController(_mockBookService.Object);
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
        public void Add_BookTitleAlreadyExists_ShoudReturnBadRequest()
        {
            //Arrange
            var book = new Book { Name = "Le Petit Prince" };
            List<Book> books = new List<Book>();
            books.Add(book);
            _mockBookService.Setup(s => s.GetAll(null, null)).Returns(books);


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

    }
}
