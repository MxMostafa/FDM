



using Client.Domain.Dtos;
using Client.Domain.Dtos.Request.FileTypeGroup;
using Client.Domain.Dtos.Response.AppSetting;
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
    Task<ResultPattern<FileTypeGroupResDto?>> GetFileTypeGroupByIdAsync(int id);
    Task<ResultPattern<FileTypeGroupResDto?>> GetFileTypeGroupByTitleAsync(string title);
    Task<ResultPattern<FileTypeGroupResDto?>> AddFileTypeGroupAsync(AddFileTypeGroupReqDto model);
    Task<ResultPattern<FileTypeGroupResDto?>> UpdateFileTypeGroupAsync(UpdateFileTypeGroupReqDto model);
    #endregion
}
