using System.Collections.Generic;
using System.Data;

namespace Vectra.Avaliacao.Backend.Domain.Entities;

public class User : BaseEntity<int>
{
    public string? Email { get; private set; }
    public string? PasswordHash { get; private set; }
    public List<Role>? Roles { get; private set; }
    public List<Account>? Accounts { get; private set; }
}
