



using Client.Domain.Dtos;
using Client.Domain.Dtos.Request.FileTypeGroup;
using Client.Domain.Dtos.Response.AppSetting;
using Client.Domain.Dtos.Response.FileTypeGroup;

namespace Client.Domain.Interfaces.Services;

public interface IAppSettingService
{
    Task<ResultPattern<List<AppSettingResDto>>> GetGeneralAppSettingAsync();
    Task<ResultPattern<bool>> AddGeneralAppSettingAsync(string key, string value);
    Task<ResultPattern<bool>> AddGeneralAppSettingsAsync(Dictionary<string, string> keyValuePairs);
    Task<ResultPattern<T?>> GetAppSettingByKeyAsync<T>(string key, T? defaultValue = default);
    #region FileTypeGroup
    Task<ResultPattern<List<FileTypeGroupResDto>>> GetAllFileTypeGroupsAsync();
    Task<ResultPattern<FileTypeGroupResDto?>> GetFileTypeGroupByIdAsync(int id);
    Task<ResultPattern<FileTypeGroupResDto?>> GetByFileExtensionAsync(string extension);
    Task<ResultPattern<FileTypeGroupResDto?>> GetFileTypeGroupByTitleAsync(string title);
    Task<ResultPattern<FileTypeGroupResDto?>> AddFileTypeGroupAsync(AddFileTypeGroupReqDto model);
    Task<ResultPattern<FileTypeGroupResDto?>> UpdateFileTypeGroupAsync(UpdateFileTypeGroupReqDto model);
    Task<ResultPattern<bool>> DeleteFileTypeGroupAsync(int fileTypeGroupId);

    Task<ResultPattern<string?>> GetTempDownloadPathAsync();
    #endregion
}
