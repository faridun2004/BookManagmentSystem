using BookManagmentSystem.API.Controllers;
using BookManagmentSystem.Application.CQRS.Authors.Commands.Create;
using BookManagmentSystem.Application.CQRS.Authors.Commands.Delete;
using BookManagmentSystem.Application.CQRS.Authors.Commands.Update;
using BookManagmentSystem.Application.CQRS.Authors.Queries.GetAll;
using BookManagmentSystem.Application.CQRS.Authors.Queries.GetById;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.NUnit.Tests
{
    public class AuthorsControllerTests
    {
        private Mock<IMediator> _mockMediator;
        private AuthorsController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new AuthorsController(_mockMediator.Object);
        }

        [Test]
        public async Task CreateClient_ValidCommand_ReturnsOk()
        {
            // Arrange
            var command = new CreateAuthorCommand { FullName = "John Doe" };
            var author = new Author { Id = Guid.NewGuid(), FullName = "John Doe" };
            _mockMediator.Setup(m => m.Send(command, default)).ReturnsAsync((author, "Success"));

            // Act
            var result = await _controller.CreateClient(command);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(author, okResult.Value);
        }

        [Test]
        public async Task CreateClient_InvalidCommand_ReturnsBadRequest()
        {
            // Arrange
            var command = new CreateAuthorCommand { FullName = "" };
            _mockMediator.Setup(m => m.Send(command, default)).ReturnsAsync((null, "Invalid data"));

            // Act
            var result = await _controller.CreateClient(command);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.AreEqual(400, badRequestResult.StatusCode);
            Assert.AreEqual("Invalid data", badRequestResult.Value);
        }

        [Test]
        public async Task GetClientById_ExistingId_ReturnsOk()
        {
            // Arrange
            var id = Guid.NewGuid();
            var author = new Author { Id = id, FullName = "John Doe" };
            _mockMediator.Setup(m => m.Send(It.Is<GetAuthorByIdQuery>(q => q.Id == id), default)).ReturnsAsync(author);

            // Act
            var result = await _controller.GetClientById(id);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(author, okResult.Value);
        }

        [Test]
        public async Task GetClientById_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockMediator.Setup(m => m.Send(It.Is<GetAuthorByIdQuery>(q => q.Id == id), default)).ReturnsAsync((Author)null);

            // Act
            var result = await _controller.GetClientById(id);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public async Task GetAllClients_ReturnsOk()
        {
            // Arrange
            var authors = new List<Author> { new Author { Id = Guid.NewGuid(), FullName = "John Doe" } };
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllAuthorsQuery>(), default)).ReturnsAsync(authors);

            // Act
            var result = await _controller.GetAllClients();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(authors, okResult.Value);
        }

        [Test]
        public async Task UpdateClient_ValidCommand_ReturnsOk()
        {
            // Arrange
            var id = Guid.NewGuid();
            var command = new UpdateAuthorCommand { Id = id, FullName = "Updated Name" };
            _mockMediator.Setup(m => m.Send(command, default)).ReturnsAsync((true, "Updated successfully"));

            // Act
            var result = await _controller.UpdateClient(id, command);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual("Updated successfully", okResult.Value);
        }

        [Test]
        public async Task UpdateClient_InvalidCommand_ReturnsBadRequest()
        {
            // Arrange
            var id = Guid.NewGuid();
            var command = new UpdateAuthorCommand { Id = id, FullName = "" };
            _mockMediator.Setup(m => m.Send(command, default)).ReturnsAsync((false, "Invalid data"));

            // Act
            var result = await _controller.UpdateClient(id, command);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.AreEqual(400, badRequestResult.StatusCode);
            Assert.AreEqual("Invalid data", badRequestResult.Value);
        }

        [Test]
        public async Task DeleteUser_ValidCommand_ReturnsOk()
        {
            // Arrange
            var command = new DeleteAuthorCommand { Id = Guid.NewGuid() };
            _mockMediator.Setup(m => m.Send(command, default)).ReturnsAsync((true, "Deleted successfully"));

            // Act
            var result = await _controller.DeleteUser(command);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual("Deleted successfully", okResult.Value);
        }

        [Test]
        public async Task DeleteUser_InvalidCommand_ReturnsBadRequest()
        {
            // Arrange
            var command = new DeleteAuthorCommand { Id = Guid.NewGuid() };
            _mockMediator.Setup(m => m.Send(command, default)).ReturnsAsync((false, "Deletion failed"));

            // Act
            var result = await _controller.DeleteUser(command);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual(400, badRequestResult.StatusCode);
            Assert.AreEqual("Deletion failed", badRequestResult.Value);
        }
    }
}
