

namespace Client.Domain.Dtos;

public class ApiResponse<T>
{
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }
    public bool IsSucceed { get; set; } = false;
    public Pagination? Pagination { get; set; }

    public ApiResponse(T data, Pagination? pagination)
    {
        Data = data;
        Pagination = pagination;
        IsSucceed = true;
    }

    public ApiResponse(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public static implicit operator ApiResponse<T>(T value) => new ApiResponse<T>(value, null);
}
