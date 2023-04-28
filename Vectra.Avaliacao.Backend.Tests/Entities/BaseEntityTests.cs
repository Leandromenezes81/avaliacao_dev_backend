using Bogus;
using System;
using Vectra.Avaliacao.Backend.Domain.Entities;

public class BaseEntityTests
{   

    [Fact]
    public void BaseEntity_CreatedAtIsSetOnCreation()
    {
        // Arrange
        var entity = new BaseEntity<int>();
        var createdAt = DateTime.UtcNow;

        // Act
        entity.CreatedAt = createdAt;

        // Assert
        Assert.Equal(createdAt, entity.CreatedAt);
    }

    [Fact]
    public void BaseEntity_IsActiveIsSetOnCreation()
    {
        // Arrange
        var entity = new BaseEntity<int>();

        // Assert
        Assert.False(entity.IsActive);
    }

    [Fact]
    public void BaseEntity_CanBeConstructedWithFaker()
    {
        // Arrange
        var faker = new Faker();
        var createdAt = faker.Date.Past();
        var updatedAt = faker.Date.Between(createdAt, DateTime.UtcNow);
        var isActive = faker.Random.Bool();
        var entity = new BaseEntity<int>
        {
            Id = faker.Random.Int(),
            CreatedAt = createdAt,
            UpdatedAt = updatedAt,
            IsActive = isActive
        };

        // Assert
        Assert.Equal(createdAt, entity.CreatedAt);
        Assert.Equal(updatedAt, entity.UpdatedAt);
        Assert.Equal(isActive, entity.IsActive);
    }
}
