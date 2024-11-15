
using Client.Domain.Dtos.Response.FileTypeGroup;
using MapsterMapper;
using System.Collections.Generic;

namespace Client.Domain.Services;
public class AppSettingService : IAppSettingService
{
    private readonly IAppSettingRepository _appSettingRepository;
    private readonly IFileTypeGroupRepository _fileTypeGroupRepository;
    private readonly IMapper _mapper;
    public AppSettingService(IAppSettingRepository appSettingRepository, IMapper mapper, IFileTypeGroupRepository fileTypeGroupRepository)
    {
        _appSettingRepository = appSettingRepository;
        _mapper = mapper;
        _fileTypeGroupRepository = fileTypeGroupRepository;
    }

    public async Task<ResultPattern<bool>> AddGeneralAppSettingAsync(string key, string value)
    {
        var appSetting = await _appSettingRepository.GetAppSettingByTypeAndKeyAsync(AppSettingType.General, key);

        if (appSetting != null)
        {
            appSetting.Value = value;
            await _appSettingRepository.UpdateAppSettingAsync(appSetting);
            return true;
        }

        await _appSettingRepository.AddAppSettingAsync(new AppSetting()
        {
            Id = 0,
            Key = key,
            AppSettingType = AppSettingType.General,
            Value = value
        });

        return true;
    }

    public async Task<ResultPattern<bool>> AddGeneralAppSettingsAsync(Dictionary<string, string> keyValuePairs)
    {
        var addList = new List<AppSetting>();
        var updateList = new List<AppSetting>();

        foreach (var item in keyValuePairs)
        {
            var appSetting = await _appSettingRepository.GetAppSettingByTypeAndKeyAsync(AppSettingType.General, item.Key);

            if (appSetting != null)
            {
                appSetting.Value = item.Value;
                updateList.Add(appSetting);
                continue;
            }

            addList.Add(new AppSetting()
            {
                Id = 0,
                Key = item.Key,
                AppSettingType = AppSettingType.General,
                Value = item.Value
            });
        }

        if (addList.Any())
            await _appSettingRepository.AddAppSettingAsync(addList);

        if (updateList.Any())
            await _appSettingRepository.UpdateAppSettingAsync(updateList);

        return true;
    }

    public async Task<ResultPattern<List<AppSettingResDto>>> GetGeneralAppSettingAsync()
    {
        var appSettings = await _appSettingRepository.GetAppSettingByTypeAsync(AppSettingType.General);
        var result = _mapper.Map<List<AppSettingResDto>>(appSettings);

        return result;
    }

    public Task<ResultPattern<AppSettingResDto?>> GetAppSettingByKeyAsync(string key)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultPattern<List<FileTypeGroupResDto>>> GetAllFileTypeGroupsAsync()
    {
        var fileTypeGroups = await _fileTypeGroupRepository.GetAllAsync();

        var result = fileTypeGroups.Select(fg => new FileTypeGroupResDto()
        {
            Id = fg.Id,
            Title = fg.Title,
            FileExtensions = fg.FileExtensions,
            IconName = fg.IconName
        }).ToList();

        return result;
    }
}
