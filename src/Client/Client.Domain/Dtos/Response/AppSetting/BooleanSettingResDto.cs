

namespace Client.Domain.Dtos.Response.AppSetting;

public record BooleanSettingResDto:IBaseDto
{
    public bool Value { get; set; }
}
