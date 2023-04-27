namespace Vectra.Avaliacao.Backend.Application.ViewModels;

public class PaginationViewModel<T>
{  
    public string Total { get; set; } = string.Empty;
    public string Page { get; set; } = string.Empty;
    public string PageSize { get; set; } = string.Empty;
    public  T? List { get; set; }
}
