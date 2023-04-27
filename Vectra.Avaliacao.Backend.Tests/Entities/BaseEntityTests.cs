using System;
using Xunit;
using Vectra.Avaliacao.Backend.Domain.Entities;

public class BaseEntityTests
{
    [Fact]
    public void BaseEntity_IdIsNullable()
    {
        // Arrange
        var entity = new BaseEntity<string>();

        // Act
        entity.Id = null;

        // Assert
        Assert.Null(entity.Id);
    }

    [Fact]
    public void BaseEntity_CreatedAt_IsInitialized()
    {
        // Arrange
        var entity = new BaseEntity<int>();

        // Assert
        Assert.NotEqual(DateTime.Now, entity.CreatedAt);
    }

    [Fact]
    public void BaseEntity_UpdatedAt_IsInitialized()
    {
        // Arrange
        var entity = new BaseEntity<int>();

        // Assert
        Assert.NotEqual(DateTime.Now, entity.UpdatedAt);
    }

    [Fact]
    public void BaseEntity_IsActive_DefaultValueIsFalse()
    {
        // Arrange
        var entity = new BaseEntity<int>();

        // Assert
        Assert.False(entity.IsActive);
    }
}
