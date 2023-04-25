namespace Vectra.Avaliacao.Backend.Domain.Entities;

public class Account : BaseEntity<int>
{
    public int UserId { get; set; }
    public string? Branch { get; set; }
    public string? Number { get; set; }
    public User? Client { get; set; }
    public decimal? Balance { get; set; }
}
