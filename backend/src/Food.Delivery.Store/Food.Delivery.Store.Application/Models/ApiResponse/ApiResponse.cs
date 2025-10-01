namespace Food.Delivery.Store.Application.Models.ApiResponse;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Content { get; set; }
    public string? Error { get; set; }
}
