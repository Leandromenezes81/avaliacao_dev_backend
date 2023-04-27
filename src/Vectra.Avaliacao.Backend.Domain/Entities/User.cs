using System;
using System.Collections.Generic;

namespace Vectra.Avaliacao.Backend.Domain.Entities;

public class User : BaseEntity<int>
{
    public User()
    {

    }

    public User(string name, string email, string passwordHash, List<Role> roles, DateTime createdAt, DateTime updatedAt, bool isActive)
    {
        Id = 0;
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Roles = roles;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
    }

    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public List<Role> Roles { get; set; } = new List<Role>();
    public List<Account> Accounts { get; set; } = new List<Account>();
}
