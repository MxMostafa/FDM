
namespace Client.Domain.Dtos.Response.AppSetting;

public record AppSettingResDto:IBaseDto
{
    public required string Key { get; set; }
    public  string? Value { get; set; }
}
