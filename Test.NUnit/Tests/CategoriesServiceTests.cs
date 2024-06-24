using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.NUnit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BookManagmentSystem.Application.InterfaceRepositories;
    using BookManagmentSystem.Domain.Entities;
    using BookManagmentSystem.Infrastructure.Services;
    using Moq;
    using NSubstitute;

    namespace MyApp.Tests
    {
        [TestFixture]
        public class CategoryServiceTests
        {
            private Mock<ISQLRepository<Category>> _mockRepository;
            private CategoryService _categoryService;

            [SetUp]
            public void SetUp()
            {
                _mockRepository = new Mock<ISQLRepository<Category>>();
                _categoryService = new CategoryService(_mockRepository.Object);
            }

            [Test]
            public void GetAll_ReturnsAllCategories()
            {
                // Arrange
                var categories = new List<Category>
            {
                new Category { Id = Guid.NewGuid(), Name = "Category1" },
                new Category { Id = Guid.NewGuid(), Name = "Category2" }
            }.AsQueryable();

                _mockRepository.Setup(repo => repo.GetAll()).Returns(categories);

                // Act
                var result = _categoryService.GetAll();

                // Assert
                Assert.AreEqual(2, result.Count());
                Assert.AreEqual("Category1", result.First().Name);
            }

            [Test]
            public async Task GetById_ExistingId_ReturnsCategory()
            {
                // Arrange
                var categoryId = Guid.NewGuid();
                var category = new Category { Id = categoryId, Name = "Category1" };

                _mockRepository.Setup(repo => repo.GetById(categoryId)).ReturnsAsync(category);

                // Act
                var result = await _categoryService.GetById(categoryId);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual("Category1", result.Name);
            }

            [Test]
            public void TryCreate_ValidCategory_ReturnsCreatedCategory()
            {
                // Arrange
                var category = new Category { Name = "Category1" };
                var createdCategory = new Category { Id = Guid.NewGuid(), Name = "Category1" };

                _mockRepository.Setup(repo => repo.TryCreate(category, out It.Ref<string>.IsAny))
                    .Returns((Category c, out string message) => { message = "Success"; return createdCategory; });

                // Act
                var result = _categoryService.TryCreate(category, out string message);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual("Category1", result.Name);
                Assert.AreEqual("Success", message);
            }

            [Test]
            public void TryCreate_InvalidCategory_ReturnsNull()
            {
                // Arrange
                var category = new Category { Name = "" };

                // Act
                var result = _categoryService.TryCreate(category, out string message);

                // Assert
                Assert.IsNull(result);
                Assert.AreEqual("The first name or last name is be empty", message);
            }

            [Test]
            public void TryUpdate_ExistingId_ReturnsTrue()
            {
                // Arrange
                var categoryId = Guid.NewGuid();
                var existingCategory = new Category { Id = categoryId, Name = "Category1" };
                var updatedCategory = new Category { Name = "UpdatedCategory" };

                _mockRepository.Setup(repo => repo.GetById(categoryId)).ReturnsAsync(existingCategory);
                _mockRepository.Setup(repo => repo.TryUpdate(It.IsAny<Category>(), out It.Ref<string>.IsAny))
                    .Returns((Category c, out string message) => { message = "Success"; return true; });

                // Act
                var result = _categoryService.TryUpdate(categoryId, updatedCategory, out string message);

                // Assert
                Assert.IsTrue(result);
                Assert.AreEqual("Success", message);
                Assert.AreEqual("UpdatedCategory", existingCategory.Name);
            }

            [Test]
            public void TryUpdate_NonExistingId_ReturnsFalse()
            {
                // Arrange
                var categoryId = Guid.NewGuid();
                var updatedCategory = new Category { Name = "UpdatedCategory" };

                _mockRepository.Setup(repo => repo.GetById(categoryId)).ReturnsAsync((Category)null);

                // Act
                var result = _categoryService.TryUpdate(categoryId, updatedCategory, out string message);

                // Assert
                Assert.IsFalse(result);
                Assert.AreEqual("Item not found", message);
            }

            [Test]
            public void TryDelete_ExistingId_ReturnsTrue()
            {
                // Arrange
                var categoryId = Guid.NewGuid();

                _mockRepository.Setup(repo => repo.TryDelete(categoryId, out It.Ref<string>.IsAny))
                    .Returns((Guid id, out string message) => { message = "Success"; return true; });

                // Act
                var result = _categoryService.TryDelete(categoryId, out string message);

                // Assert
                Assert.IsTrue(result);
                Assert.AreEqual("Success", message);
            }

            [Test]
            public void TryDelete_NonExistingId_ReturnsFalse()
            {
                // Arrange
                var categoryId = Guid.NewGuid();

                _mockRepository.Setup(repo => repo.TryDelete(categoryId, out It.Ref<string>.IsAny))
                    .Returns((Guid id, out string message) => { message = "Item not found"; return false; });

                // Act
                var result = _categoryService.TryDelete(categoryId, out string message);

                // Assert
                Assert.IsFalse(result);
                Assert.AreEqual("Item not found", message);
            }
        }
    }

}
