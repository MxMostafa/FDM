
namespace Client.Domain.Dtos.Response.AppSetting;

public record StringSettingResDto:IBaseDto
{
    public string? Value { get; set; }
}
