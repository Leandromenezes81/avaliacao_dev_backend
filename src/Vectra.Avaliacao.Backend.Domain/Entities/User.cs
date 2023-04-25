using System;
using System.Collections.Generic;
using System.Data;

namespace Vectra.Avaliacao.Backend.Domain.Entities;

public class User : BaseEntity<int>
{
    public User()
    {
        
    }

    public User(string? email, string? passwordHash, List<Role>? roles, DateTime createdAt, DateTime updatedAt, bool isActive)
    {
        Email = email;
        PasswordHash = passwordHash;
        Roles = roles;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
    }

    public string? Email { get; private set; }
    public string? PasswordHash { get; private set; }
    public List<Role>? Roles { get; private set; }
    public List<Account>? Accounts { get; private set; }
}
