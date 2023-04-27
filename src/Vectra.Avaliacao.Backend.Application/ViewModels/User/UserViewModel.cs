namespace Vectra.Avaliacao.Backend.Application.ViewModels.User;

public class UserViewModel
{
    public UserViewModel(string id, string name, string email, string createdAt, string updatedAt, string isActive)
    {
        Id = id;
        Name = name;
        Email = email;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        IsActive = isActive;
    }

    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CreatedAt { get; set; } = string.Empty;
    public string UpdatedAt { get; set; } = string.Empty;
    public string IsActive { get; set; } = string.Empty;
}
