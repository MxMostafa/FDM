using Client.Domain.Dtos.Request.Account;
using Client.Domain.Dtos.Response.Account;

namespace Client.Domain.Interfaces.Services;

public interface IAccountService
{
    Task<ApiResponse<LoginWithOTPResDto>> LoginWithOTPAsync(LoginWithOTPReqDto loginWithOTPResDto);
    Task<ApiResponse<ConfirmLoginWithOTPResDto>> ConfirmLoginWithOTPAsync(ConfirmLoginWithOTPReqDto confirmLoginWithOTPReqDto);
}
