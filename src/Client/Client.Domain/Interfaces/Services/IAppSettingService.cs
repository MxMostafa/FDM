



using Client.Domain.Dtos.Response.FileTypeGroup;

namespace Client.Domain.Interfaces.Services;

public interface IAppSettingService
{
    Task<ResultPattern<List<AppSettingResDto>>> GetGeneralAppSettingAsync();
    Task<ResultPattern<AppSettingResDto?>> GetAppSettingByKeyAsync(string key);
    Task<ResultPattern<bool>> AddGeneralAppSettingAsync(string key, string value);
    Task<ResultPattern<bool>> AddGeneralAppSettingsAsync(Dictionary<string, string> keyValuePairs);

    #region FileTypeGroup
    Task<ResultPattern<List<FileTypeGroupResDto>>> GetAllFileTypeGroupsAsync();
    Task<ResultPattern<bool>> AddFileGroupAsync(string title,string suffixName);

    Task<ResultPattern<FileTypeGroupResDto?>> GetSelectedFileTypeGroupAsync(int id);
    Task<ResultPattern<bool>> EditFileGroupAsync(FileTypeGroupResDto value);
    #endregion
}
