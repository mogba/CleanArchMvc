using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryTest
    {
        [Fact(DisplayName = "Create category with valid state")]
        public void CreateCategory_GivenValidParameters_ShouldCreateCategoryWithValidState()
        {
            // Act
            Action action = () => new Category(1, "Category name");

            // Assert
            action.Should().NotThrow<DomainValidationException>();
        }

        [Fact(DisplayName = "Create category with invalid ID value")]
        public void CreateCategory_GivenInvalidIdValue_ShouldThrowErrorInvalidIdValue()
        {
            // Act
            Action action = () => new Category(-1, "Category name");

            // Assert
            action.Should().Throw<DomainValidationException>().WithMessage("Invalid ID value.");
        }

        [Fact(DisplayName = "Create category with short name value")]
        public void CreateCategory_GivenShortNameValue_ShouldThrowError()
        {
            // Act
            Action action = () => new Category(1, "Ca");

            // Assert
            action.Should().Throw<DomainValidationException>().WithMessage("Invalid name. Name must be a minimum of 3 characters.");
        }

        [Fact(DisplayName = "Create category with empty name value")]
        public void CreateCategory_GivenEmptyNameValue_ShouldThrowErrorNameIsRequired()
        {
            // Act
            Action action = () => new Category(1, "");

            // Assert
            action.Should().Throw<DomainValidationException>().WithMessage("Invalid name. Name is required.");
        }

        [Fact(DisplayName = "Create category with null name value")]
        public void CreateCategory_GivenNullNameValue_ShouldThrowErrorInvalidNameValue()
        {
            // Act
            Action action = () => new Category(1, null);

            // Assert
            action.Should().Throw<DomainValidationException>();
        }
    }
}
