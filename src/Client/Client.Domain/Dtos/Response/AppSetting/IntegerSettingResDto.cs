

namespace Client.Domain.Dtos.Response.AppSetting;

public record IntegerSettingResDto:IBaseDto
{
    public int?  Value { get; set; }
}
