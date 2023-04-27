namespace Vectra.Avaliacao.Backend.Application.ViewModels.Account;

public class AccountViewModel
{
    public AccountViewModel(string id, string branch, string number, string client, string balance, string createdAt, string updatedAt, string isActive)
    {
        Id = id;
        Branch = branch;
        Number = number;
        Client = client;
        Balance = balance;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
    }

    public string Id { get; set; } = string.Empty;
    public string Branch { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Client { get; set; } = string.Empty;
    public string Balance { get; set; } = string.Empty;
    public string CreatedAt { get; set; } = string.Empty;
    public string UpdatedAt { get; set; } = string.Empty;
    public string IsActive { get; set; } = string.Empty;
}
