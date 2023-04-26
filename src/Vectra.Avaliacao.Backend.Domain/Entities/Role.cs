using System.Collections.Generic;

namespace Vectra.Avaliacao.Backend.Domain.Entities
{
    public class Role : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new List<User>();
    }
}