using System;

namespace Vectra.Avaliacao.Backend.Domain.Entities;

public class Account : BaseEntity<int>
{
    public Account()
    {
        
    }

    public Account(int userId, string branch, string number, decimal balance, DateTime createdAt, DateTime updatedAt, bool isActive, User user)
    {
        UserId = userId;
        Branch = branch;
        Number = number;
        Balance = balance;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
        User = user;
    }

    public int UserId { get; set; } = 0;
    public string Branch { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public decimal Balance { get; set; } = 0.00M;
    public User User { get; set; } = new User();
}
