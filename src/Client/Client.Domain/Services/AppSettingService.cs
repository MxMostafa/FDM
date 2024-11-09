
using MapsterMapper;

namespace Client.Domain.Services;
public class AppSettingService : IAppSettingService
{
    private readonly IAppSettingRepository _appSettingRepository;
    private readonly IMapper _mapper;
    public AppSettingService(IAppSettingRepository appSettingRepository, IMapper mapper)
    {
        _appSettingRepository = appSettingRepository;
        _mapper = mapper;
    }

    public Task<ResultPattern<bool>> AddAppSettingAsync(string key, string value)
    {
        throw new NotImplementedException();
    }

    public Task<ResultPattern<bool>> AddAppSettingAsync(Dictionary<string, string> keyValuePairs)
    {
        throw new NotImplementedException();
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
}
