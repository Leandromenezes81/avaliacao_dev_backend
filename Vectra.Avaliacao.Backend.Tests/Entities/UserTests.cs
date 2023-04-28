using Bogus;
using System.Collections.Generic;
using Vectra.Avaliacao.Backend.Domain.Entities;

namespace Vectra.Avaliacao.Backend.Tests.Entities;

public class UserTests
{
    private readonly Faker<User> _faker;

    public UserTests()
    {
        _faker = new Faker<User>()
            .RuleFor(u => u.Id, f => f.Random.Int())
            .RuleFor(u => u.Name, f => f.Person.FullName)
            .RuleFor(u => u.Email, f => f.Person.Email)
            .RuleFor(u => u.PasswordHash, f => f.Random.AlphaNumeric(10))
            .RuleFor(u => u.CreatedAt, f => f.Date.Past())
            .RuleFor(u => u.UpdatedAt, f => f.Date.Recent())
            .RuleFor(u => u.IsActive, f => f.Random.Bool())
            .RuleFor(u => u.Roles, f => new List<Role>());
    }

    [Fact]
    public void UserMock_GenerateUser_ReturnsValidUser()
    {
        // Arrange
        var user = _faker.Generate();

        // Assert
        Assert.NotNull(user);
        Assert.NotEqual(0, user.Id);
        Assert.NotNull(user.Name);
        Assert.NotNull(user.Email);
        Assert.NotNull(user.PasswordHash);
    }
}
