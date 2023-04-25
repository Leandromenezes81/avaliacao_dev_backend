using System;

namespace Vectra.Avaliacao.Backend.Domain.Entities;

public class BaseEntity<T>
{
    public T? Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
}
