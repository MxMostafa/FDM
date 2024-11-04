

namespace Client.Domain.Dtos;

public class ResultPattern<T>
{
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }
    public bool IsSucceed { get; set; } = false;
    public Pagination? Pagination { get; set; }

    public ResultPattern(T data, Pagination? pagination)
    {
        Data = data;
        Pagination = pagination;
        IsSucceed = true;
    }

    public ResultPattern(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public static implicit operator ResultPattern<T>(T value) => new ResultPattern<T>(value, null);
}
