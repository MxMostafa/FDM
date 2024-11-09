namespace Client.Domain.Entites;
public class AppSetting : BaseEntity<int>
{
    public required string Key { get; set; }
    public string? Value { get; set; }
    public AppSettingType AppSettingType { get; set; }
}
