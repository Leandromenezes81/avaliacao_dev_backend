using Bogus;
using System.Collections.Generic;
using Vectra.Avaliacao.Backend.Domain.Entities;

namespace Vectra.Avaliacao.Backend.Tests.Entities;

public class RoleTests
{
    private readonly Faker<Role> _faker;

    public RoleTests()
    {
        _faker = new Faker<Role>()
            .RuleFor(r => r.Id, f => f.Random.Int())
            .RuleFor(r => r.Name, f => f.Name.JobTitle())
            .RuleFor(r => r.CreatedAt, f => f.Date.Past())
            .RuleFor(r => r.UpdatedAt, f => f.Date.Recent())
            .RuleFor(r => r.IsActive, f => f.Random.Bool())
            .RuleFor(r => r.Users, f => new List<User>());
    }

    [Fact]
    public void RoleMock_GenerateRole_ReturnsValidRole()
    {
        // Arrange
        var role = _faker.Generate();

        // Assert
        Assert.NotNull(role);
        Assert.NotEqual(0, role.Id);
        Assert.NotNull(role.Name);
    }
}
