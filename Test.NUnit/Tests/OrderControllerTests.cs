using BookManagmentSystem.API.Controllers;
using BookManagmentSystem.Application.CQRS.Authors.Queries.GetById;
using BookManagmentSystem.Domain.Entities;
using MediatR;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BookManagementSystem.NUnit.IntegrationTests.Tests
{
    [TestFixture]
    public class AuthorsControllerTests
    {
        private AuthorsController _controller;
        private Mock<IMediator> _mediatorMock;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new AuthorsController(_mediatorMock.Object);
        }

        [Test]
        public async Task GetAuthorById_Returns_OkObjectResult_With_Author()
        {
            // Arrange
            var authorId = Guid.NewGuid();
            var author = new Author { Id = authorId, FullName = "Test Author" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAuthorByIdQuery>(), CancellationToken.None))
                         .ReturnsAsync(author);
            // Act
            var result = await _controller.GetById(authorId);

            // Assert
            result.Should().BeOfType<ActionResult<Author>>();
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var model = okResult.Value.Should().BeAssignableTo<Author>().Subject;
            model.Should().BeEquivalentTo(author);
        }
    }
}
