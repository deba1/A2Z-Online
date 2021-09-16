using API.Controllers;
using Application.DTOs.EntityDTOs;
using Application.Managers;
using Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace API.IntegrationTests.ControllerTests
{
    public class BrandsControllerTests
    {
        private readonly Mock<IBrandManager> _mock;

        public BrandsControllerTests()
        {
            _mock = new Mock<IBrandManager>();
        }

        [Fact]
        public async Task Get_WithExsistingBrands_Returns_OkObjectContent()
        {
            // Arrange
            var expected = CreateRandomBrands(2);
            Expression<Func<IBrandManager, Task<List<Brand>>>> call = x => x.GetAll();
            _mock.Setup(call)
                .ReturnsAsync(expected);

            _mock.Setup(call)
                .ReturnsAsync(expected).Verifiable("Method not called");

            var controller = new BrandsController(_mock.Object);

            // Act
            var result = await controller.GetAll();
            var okObject = result.Result as OkObjectResult;

            // Assert
            var actual = okObject.Value as List<Brand>;
            actual.Should().BeEquivalentTo(expected,
                options => options.ComparingByMembers<Brand>());
            actual.Should().HaveCount(2);

            _mock.Verify(call, Times.Once);
            _mock.VerifyAll();
            //Assert.Throws<MockException>(() => mock.VerifyAll());
        }

        [Fact]
        public async Task GetById_WithExsistingBrand_Returns_OkObjectResult()
        {
            // Arrange
            var expected = CreateRandomBrands(1).FirstOrDefault();

            Expression<Func<IBrandManager, Task<Brand>>> call = x => x.GetById(It.IsAny<int>());
            _mock.Setup(call)
                .ReturnsAsync(expected);

            // Act
            var controller = new BrandsController(_mock.Object);
            var result = await controller.GetById(It.IsAny<int>());
            var okObject = result.Result as OkObjectResult;

            // Assert
            var actual = okObject.Value as Brand;
            actual.Should().BeEquivalentTo(expected,
                options => options.ComparingByMembers<Brand>());

            _mock.Verify(call, Times.Once);
            _mock.VerifyAll();
        }

        [Fact]
        public async Task GetById_WithUnExsistingBrand_Returns_NotFound()
        {
            // Arrange
            _mock.Setup(repo => repo.GetById(It.IsAny<int>()))
                .ReturnsAsync((Brand)null);

            var controller = new BrandsController(_mock.Object);

            // Act
            var result = await controller.GetById(It.IsAny<int>());

            // Assert
            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Add_Brand_Returns_CreatedAtActionResult()
        {
            // Arrange
            var expected = CreateRandomBrands(1).FirstOrDefault();

            Expression<Func<IBrandManager, Task<Brand>>> call = x => x.Add(It.IsAny<BrandDTO>());

            _mock.Setup(call)
                .ReturnsAsync(expected);

            // Act
            var controller = new BrandsController(_mock.Object);
            var result = await controller.Add(It.IsAny<BrandDTO>());
            var createdObject = result.Result as CreatedAtActionResult;

            // Assert
            var actual = createdObject.Value as Brand;
            actual.Should().BeEquivalentTo(expected,
                options => options.ComparingByMembers<Brand>());

            _mock.Verify(call, Times.Once);
            _mock.VerifyAll();
        }

        [Fact]
        public async Task Update_Returns_NoContent()
        {
            // Arrange
            var expected = CreateRandomBrands(1).FirstOrDefault();

            Expression<Func<IBrandManager, Task<Brand>>> call = x => x.GetById(It.IsAny<int>());
            _mock.Setup(call)
                .ReturnsAsync(expected);

            var controller = new BrandsController(_mock.Object);

            // Act
            var result = await controller.Update(It.IsAny<int>(), It.IsAny<BrandDTO>());

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task Update_Returns_NotFoundResult()
        {
            // Arrange
            Expression<Func<IBrandManager, Task<Brand>>> call = x => x.GetById(It.IsAny<int>());

            _mock.Setup(call)
                .ReturnsAsync((Brand)null);

            // Act
            var controller = new BrandsController(_mock.Object);
            var result = await controller.Update(It.IsAny<int>(), It.IsAny<BrandDTO>());

            // Assert
            result.Should().BeOfType<NotFoundResult>();

            _mock.Verify(call, Times.Once);
            _mock.VerifyAll();
        }

        [Fact]
        public async Task Remove_Returns_NoContent()
        {
            // Arrange
            var expected = CreateRandomBrands(1).FirstOrDefault();

            Expression<Func<IBrandManager, Task<Brand>>> call = x => x.GetById(It.IsAny<int>());
            _mock.Setup(call)
                .ReturnsAsync(expected);

            var controller = new BrandsController(_mock.Object);

            // Act
            var result = await controller.Remove(It.IsAny<int>());

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task Remove_Returns_NotFoundResult()
        {
            // Arrange
            Expression<Func<IBrandManager, Task<Brand>>> call = x => x.GetById(It.IsAny<int>());

            _mock.Setup(call)
                .ReturnsAsync((Brand)null);

            // Act
            var controller = new BrandsController(_mock.Object);
            var result = await controller.Remove(It.IsAny<int>());

            // Assert
            result.Should().BeOfType<NotFoundResult>();

            _mock.Verify(call, Times.Once);
            _mock.VerifyAll();
        }

        private static List<Brand> CreateRandomBrands(int num)
        {
            var list = new List<Brand>();

            for (int i = 0; i < num; i++)
            {
                var listItem = new Brand
                {
                    Id = It.IsAny<int>(),
                    Name = Guid.NewGuid().ToString(),
                    LogoPath = Guid.NewGuid().ToString(),
                    CreatedBy = It.IsAny<int>(),
                    ModifiedBy = It.IsAny<int>(),
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                    SlNo = It.IsAny<int>(),
                };

                list.Add(listItem);
            }

            return list;
        }
    }
}
