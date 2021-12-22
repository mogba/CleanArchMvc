using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Exceptions;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductTest
    {
        [Fact(DisplayName = "Create product with negative ID")]
        public void CreateProduct_GivenNegativeId_ShouldThrowErrorInvalidIdValue()
        {
            // Act
            Action action = () => GetNewProduct(id: -1);

            // Assert
            action.Should().Throw<DomainValidationException>().WithMessage("Invalid ID value.");
        }

        [Theory(DisplayName = "Create product with invalid name")]
        [InlineData(default, "Invalid name. Name is required.")]
        [InlineData("Na", "Invalid name. Name must be a minimum of 3 characters.")]
        public void CreateCategory_GivenInvalidName_ShouldThrowError(string name, string errorMessage)
        {
            // Act
            Action action = () => GetNewProduct(name: name);

            // Assert
            action.Should().Throw<DomainValidationException>().WithMessage(errorMessage);
        }

        [Theory(DisplayName = "Create product with invalid description")]
        [InlineData(default, "Invalid description. Description is required.")]
        [InlineData("Desc", "Invalid description. Description must be a minimum of 5 characters.")]
        public void CreateCategory_GivenInvalidDescription_ShouldThrowError(string description, string errorMessage)
        {
            // Act
            Action action = () => GetNewProduct(description: description);

            // Assert
            action.Should().Throw<DomainValidationException>().WithMessage(errorMessage);
        }

        [Fact(DisplayName = "Create product with negative price")]
        public void CreateProduct_GivenNegativePrice_ShouldThrowError()
        {
            // Act
            Action action = () => GetNewProduct(price: -1m);

            // Assert
            action.Should().Throw<DomainValidationException>().WithMessage("Invalid price value. Price must be equal or greater than 0.");
        }

        [Fact(DisplayName = "Create product with negative stock")]
        public void CreateProduct_GivenNegativeStock_ShouldThrowError()
        {
            // Act
            Action action = () => GetNewProduct(stock: -1);

            // Assert
            action.Should().Throw<DomainValidationException>().WithMessage("Invalid stock value. Stock must be equal or greater than 0.");
        }

        [Fact(DisplayName = "Create product without image")]
        public void CreateProduct_GivenWithoutImage_ShouldThrowError()
        {
            // Act
            Action action = () => GetNewProduct(image: default);

            // Assert
            action.Should().NotThrow<DomainValidationException>();
        }

        [Fact(DisplayName = "Create product with too big image")]
        public void CreateProduct_GivenTooBigImage_ShouldThrowError()
        {
            // Act
            Action action = () => GetNewProductWithTooBigImage();

            // Assert
            action.Should().Throw<DomainValidationException>().WithMessage("Invalid image. Image must be a maximum of 250 characters");
        }

        [Fact(DisplayName = "Create product with valid data")]
        public void CreateProduct_GivenValidParameters_ShouldCreateProductWithValidState()
        {
            // Act
            Action action = () => GetNewProduct();

            // Assert
            action.Should().NotThrow<DomainValidationException>();
        }

        private Product GetNewProductWithTooBigImage()
        {
            var tooBigImage = string.Join("", new string[15].Select(i => i = "this is a big image "));
            return GetNewProduct(image: tooBigImage);
        }

        private Product GetNewProduct(
            int id = 1, 
            string name = "Product name", 
            string description = "Product description", 
            decimal price = 9.99m, 
            int stock = 99, 
            string image = "Product image")
            => new Product(id, name, description, price, stock, image);
    }
}
