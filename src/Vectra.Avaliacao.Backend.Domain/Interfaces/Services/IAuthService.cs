using System.Collections.Generic;
using Vectra.Avaliacao.Backend.Domain.Entities;

namespace Vectra.Avaliacao.Backend.Domain.Interfaces.Services;

public interface IAuthService
{
    string GenerateJwtToken(string email, List<Role> roles);
    string GeneratePasswordHash(string password);
}
