
using Client.Domain.Dtos.Request.FileTypeGroup;
using Client.Domain.Dtos.Response.FileTypeGroup;
using Client.Domain.Entites;
using Client.Domain.Interfaces.General.Errors;
using MapsterMapper;
using System.Collections.Generic;

namespace Client.Application.Services;
public class AppSettingService : IAppSettingService
{
    private readonly IAppSettingRepository _appSettingRepository;
    private readonly IFileTypeGroupRepository _fileTypeGroupRepository;
    private readonly IMapper _mapper;

    private readonly IAppErrors _appErrors;
    public AppSettingService(IAppSettingRepository appSettingRepository, IMapper mapper, IFileTypeGroupRepository fileTypeGroupRepository, IAppErrors appErrors)
    {
        _appSettingRepository = appSettingRepository;
        _mapper = mapper;
        _fileTypeGroupRepository = fileTypeGroupRepository;
        _appErrors = appErrors;
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


    public async Task<ResultPattern<List<FileTypeGroupResDto>>> GetAllFileTypeGroupsAsync()
    {
        var fileTypeGroups = await _fileTypeGroupRepository.GetAllAsync();

        var result = fileTypeGroups.Select(fg => new FileTypeGroupResDto()
        {
            Id = fg.Id,
            Title = fg.Title,
            FileExtensions = fg.FileExtensions,
            IconName = fg.IconName,
            SavePath = fg.SavePath,
            FolderName = fg.FolderName
        }).ToList();

        return result;
    }

    public async Task<ResultPattern<T?>> GetAppSettingByKeyAsync<T>(string key, T? defaultValue = default)
    {
        var appSetting = await _appSettingRepository.GetAppSettingByKeyAsync(key);
        if (appSetting == null)
            return defaultValue;

        try
        {
            // تلاش برای تبدیل مقدار به نوع T
            var value = Convert.ChangeType(appSetting.Value, typeof(T));
            if (value == null) return defaultValue;
            return new ResultPattern<T?>((T)value, null);

        }
        catch
        {
            return defaultValue; // در صورت خطا، مقدار پیش‌فرض بازگردانده شود
        }
    }

    public async Task<ResultPattern<FileTypeGroupResDto?>> GetFileTypeGroupByIdAsync(int id)
    {
        var fileTypeGroup = await _fileTypeGroupRepository.GetByIdAsync(id);

        if (fileTypeGroup == null)
            return new ResultPattern<FileTypeGroupResDto?>(_appErrors.NotFound);

        return new FileTypeGroupResDto()
        {
            Id = fileTypeGroup.Id,
            Title = fileTypeGroup.Title,
            FileExtensions = fileTypeGroup.FileExtensions,
            IconName = fileTypeGroup.IconName,
            SavePath = fileTypeGroup.SavePath,
            FolderName = fileTypeGroup.FolderName
        };

    }

    public async Task<ResultPattern<FileTypeGroupResDto?>> GetByFileExtensionAsync(string extension)
    {
        var fileTypeGroup = await _fileTypeGroupRepository.GetByFileExtensionAsync(extension);

        if (fileTypeGroup == null)
            return new ResultPattern<FileTypeGroupResDto?>(_appErrors.NotFound);

        return new FileTypeGroupResDto()
        {
            Id = fileTypeGroup.Id,
            Title = fileTypeGroup.Title,
            FileExtensions = fileTypeGroup.FileExtensions,
            IconName = fileTypeGroup.IconName,
            SavePath = fileTypeGroup.SavePath,
            FolderName = fileTypeGroup.FolderName
        };

    }

    public async Task<ResultPattern<FileTypeGroupResDto?>> GetFileTypeGroupByTitleAsync(string title)
    {
        var fileTypeGroup = await _fileTypeGroupRepository.GetByTitleAsync(title);

        if (fileTypeGroup == null)
            return new ResultPattern<FileTypeGroupResDto?>(_appErrors.NotFound);

        return new FileTypeGroupResDto()
        {
            Id = fileTypeGroup.Id,
            Title = fileTypeGroup.Title,
            FileExtensions = fileTypeGroup.FileExtensions,
            IconName = fileTypeGroup.IconName,
            SavePath = fileTypeGroup.SavePath,
            FolderName = fileTypeGroup.FolderName
        };

    }

    public async Task<ResultPattern<FileTypeGroupResDto?>> AddFileTypeGroupAsync(AddFileTypeGroupReqDto model)
    {
        var fileTypeGroup = await _fileTypeGroupRepository.GetByTitleAsync(model.Title);

        if (fileTypeGroup != null)
            return new ResultPattern<FileTypeGroupResDto?>(_appErrors.DuplicatedFileTypeGroupError);

        fileTypeGroup = new FileTypeGroup()
        {
            Id = 0,
            Title = model.Title,
            FileExtensions = model.FileExtensions,
            SavePath = model.SavePath,
            FolderName = model.FolderName
        };

        await _fileTypeGroupRepository.AddAsync(fileTypeGroup);

        return new FileTypeGroupResDto()
        {
            Id = fileTypeGroup.Id,
            Title = fileTypeGroup.Title,
            FileExtensions = fileTypeGroup.FileExtensions,
            IconName = fileTypeGroup.IconName,
            SavePath = fileTypeGroup.SavePath,
            FolderName = fileTypeGroup.FolderName
        };
    }

    public async Task<ResultPattern<FileTypeGroupResDto?>> UpdateFileTypeGroupAsync(UpdateFileTypeGroupReqDto model)
    {

        var fileTypeGroup = await _fileTypeGroupRepository.GetByIdAsync(model.Id);

        if (fileTypeGroup == null)
            return new ResultPattern<FileTypeGroupResDto?>(_appErrors.NotFound);


        var exitFileTypeGroupWithSameName = await _fileTypeGroupRepository.GetByTitleAsync(model.Title);

        if (exitFileTypeGroupWithSameName != null && exitFileTypeGroupWithSameName.Id != fileTypeGroup.Id)
            return new ResultPattern<FileTypeGroupResDto?>(_appErrors.DuplicatedFileTypeGroupError);

        fileTypeGroup.Title = model.Title;
        fileTypeGroup.FileExtensions = model.FileExtensions;
        fileTypeGroup.SavePath = model.SavePath;

        await _fileTypeGroupRepository.UpdateAsync(fileTypeGroup);

        return new FileTypeGroupResDto()
        {
            Id = fileTypeGroup.Id,
            Title = fileTypeGroup.Title,
            FileExtensions = fileTypeGroup.FileExtensions,
            IconName = fileTypeGroup.IconName,
            SavePath = fileTypeGroup.SavePath,
            FolderName = fileTypeGroup.FolderName
        };
    }

    public async Task<ResultPattern<bool>> DeleteFileTypeGroupAsync(int fileTypeGroupId)
    {

        var fileTypeGroup = await _fileTypeGroupRepository.GetByIdAsync(fileTypeGroupId);

        if (fileTypeGroup == null)
            return new ResultPattern<bool>(_appErrors.NotFound);


        await _fileTypeGroupRepository.SoftDeleteAsync(fileTypeGroup);


        return true;
    }
}
