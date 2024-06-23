using BookManagmentSystem.Application.InterfaceRepositories;
using BookManagmentSystem.Domain.Entities;
using BookManagmentSystem.Infrastructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.NUnit.CommonData;

namespace Test.NUnit.Tests
{
    [TestFixture]
    public class BookServiceTests: BookEntity
    {
        private Mock<ISQLRepository<Book>> _mockRepository;
        private BookService _bookService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<ISQLRepository<Book>>();
            _bookService = new BookService(_mockRepository.Object);
        }

        [Test]
        public void GetAll_ShouldReturnAllBooks()
        {
            // Arrange
            var books = new List<Book>
        {
            new Book { Id = Guid.NewGuid(), Title = "Book 1" },
            new Book { Id = Guid.NewGuid(), Title = "Book 2" }
        }.AsQueryable();
            _mockRepository.Setup(repo => repo.GetAll()).Returns(books);

            // Act
            var result = _bookService.GetAll();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Book 1", result.First().Title);
        }

        [Test]
        public void GetAll_WithPagination_ShouldReturnPagedBooks()
        {
            // Arrange
            var books = new List<Book>
        {
            new Book { Id = Guid.NewGuid(), Title = "Book 1" },
            new Book { Id = Guid.NewGuid(), Title = "Book 2" },
            new Book { Id = Guid.NewGuid(), Title = "Book 3" }
        }.AsQueryable();
            _mockRepository.Setup(repo => repo.GetAll()).Returns(books);

            // Act
            var result = _bookService.GetAll(1, 2);

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Book 2", result.First().Title);
        }

        [Test]
        public async Task GetById_ShouldReturnBook_WhenBookExists()
        {
            // Arrange
            var bookId = Guid.NewGuid();
            var book = new Book { Id = bookId, Title = "Book 1" };
            _mockRepository.Setup(repo => repo.GetById(bookId)).ReturnsAsync(book);

            // Act
            var result = await _bookService.GetById(bookId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(bookId, result.Id);
        }

        [Test]
        public async Task GetById_ShouldReturnNull_WhenBookDoesNotExist()
        {
            // Arrange
            var bookId = Guid.NewGuid();
            _mockRepository.Setup(repo => repo.GetById(bookId)).ReturnsAsync((Book)null);

            // Act
            var result = await _bookService.GetById(bookId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void TryCreate_ShouldReturnErrorMessage_WhenTitleOrAuthorIsEmpty()
        {
            // Arrange
            var book = new Book { Title = "", Author = null };
            string message;

            // Act
            var result = _bookService.TryCreate(book, out message);

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual("The first name or last name is be empty", message);
        }

        [Test]
        public void TryCreate_ShouldCallRepositoryAndReturnBook_WhenValid()
        {
            // Arrange
            var book = new Book { Title = "Book 1", Author = new Author { FullName = "Author 1" } };
            string message;
            _mockRepository.Setup(repo => repo.TryCreate(book, out message)).Returns(book);

            // Act
            var result = _bookService.TryCreate(book, out message);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Book 1", result.Title);
        }

        [Test]
        public void TryUpdate_ShouldReturnFalse_WhenBookDoesNotExist()
        {
            // Arrange
            var bookId = Guid.NewGuid();
            var book = new Book { Title = "Updated Title" };
            string message;
            _mockRepository.Setup(repo => repo.GetById(bookId)).ReturnsAsync((Book)null);

            // Act
            var result = _bookService.TryUpdate(bookId, book, out message);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual("Item not found", message);
        }

        [Test]
        public void TryUpdate_ShouldCallRepositoryAndReturnTrue_WhenBookExists()
        {
            // Arrange
            var bookId = Guid.NewGuid();
            var existingBook = new Book { Id = bookId, Title = "Original Title" };
            var updatedBook = new Book { Title = "Updated Title", Price = 20.0M, Author = new Author { FullName = "Updated Author" } };
            string message;
            _mockRepository.Setup(repo => repo.GetById(bookId)).ReturnsAsync(existingBook);
            _mockRepository.Setup(repo => repo.TryUpdate(existingBook, out message)).Returns(true);

            // Act
            var result = _bookService.TryUpdate(bookId, updatedBook, out message);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual("Updated Title", existingBook.Title);
        }

        [Test]
        public void TryDelete_ShouldCallRepositoryAndReturnTrue()
        {
            // Arrange
            var bookId = Guid.NewGuid();
            string message;
            _mockRepository.Setup(repo => repo.TryDelete(bookId, out message)).Returns(true);

            // Act
            var result = _bookService.TryDelete(bookId, out message);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
