using System;
using System.Collections.Generic;

namespace Vectra.Avaliacao.Backend.Domain.Entities;

public class User : BaseEntity<int>
{
    public User()
    {
        
    }

    public User(string email, string passwordHash, List<Role> roles, DateTime createdAt, DateTime updatedAt, bool isActive)
    {
        Id = 0;
        Email = email;
        PasswordHash = passwordHash;
        Roles = roles;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
    }

    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public List<Role> Roles { get; private set; } = new List<Role>();
    public List<Account> Accounts { get; private set; } = new List<Account>();
}
