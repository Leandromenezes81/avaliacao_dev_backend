using Bogus;
using System;
using System.Collections.Generic;
using Vectra.Avaliacao.Backend.Domain.Entities;

namespace Vectra.Avaliacao.Backend.Tests.Entities;

public class AccountTests
{
    [Fact]
    public void Account_UserIdIsSetOnCreation()
    {
        // Arrange
        var faker = new Faker();
        var userId = faker.Random.Int();
        var account = new Account(userId, "branch", "number", 0.00M, DateTime.UtcNow, DateTime.UtcNow, true, new User());

        // Assert
        Assert.Equal(userId, account.UserId);
    }

    [Fact]
    public void Account_BranchIsSetOnCreation()
    {
        // Arrange
        var faker = new Faker();
        var branch = faker.Random.String();
        var account = new Account(0, branch, "number", 0.00M, DateTime.UtcNow, DateTime.UtcNow, true, new User());

        // Assert
        Assert.Equal(branch, account.Branch);
    }

    [Fact]
    public void Account_NumberIsSetOnCreation()
    {
        // Arrange
        var faker = new Faker();
        var number = faker.Random.String();
        var account = new Account(0, "branch", number, 0.00M, DateTime.UtcNow, DateTime.UtcNow, true, new User());

        // Assert
        Assert.Equal(number, account.Number);
    }

    [Fact]
    public void Account_BalanceIsSetOnCreation()
    {
        // Arrange
        var faker = new Faker();
        var balance = faker.Random.Decimal();
        var account = new Account(0, "branch", "number", balance, DateTime.UtcNow, DateTime.UtcNow, true, new User());

        // Assert
        Assert.Equal(balance, account.Balance);
    }

    [Fact]
    public void Account_UserIsSetOnCreation()
    {
        // Arrange
        var faker = new Faker();
        var user = new User(faker.Person.FullName, faker.Person.Email, faker.Random.String(), new List<Role>(), DateTime.UtcNow, DateTime.UtcNow, true);
        var account = new Account(0, "branch", "number", 0.00M, DateTime.UtcNow, DateTime.UtcNow, true, user);

        // Assert
        Assert.Equal(user, account.User);
    }

    [Fact]
    public void Account_CanBeConstructedWithFaker()
    {
        // Arrange
        var faker = new Faker();
        var userId = faker.Random.Int();
        var branch = faker.Random.String();
        var number = faker.Random.String();
        var balance = faker.Random.Decimal();
        var createdAt = faker.Date.Past();
        var updatedAt = faker.Date.Between(createdAt, DateTime.UtcNow);
        var isActive = faker.Random.Bool();
        var user = new User(faker.Person.FullName, faker.Person.Email, faker.Random.String(), new List<Role>(), DateTime.UtcNow, DateTime.UtcNow, true);
        var account = new Account(userId, branch, number, balance, createdAt, updatedAt, isActive, user);

        // Assert
        Assert.Equal(userId, account.UserId);
        Assert.Equal(branch, account.Branch);
        Assert.Equal(number, account.Number);
        Assert.Equal(balance, account.Balance);
        Assert.Equal(createdAt, account.CreatedAt);
        Assert.Equal(updatedAt, account.UpdatedAt);
        Assert.Equal(isActive, account.IsActive);
        Assert.Equal(user, account.User);
    }
}
