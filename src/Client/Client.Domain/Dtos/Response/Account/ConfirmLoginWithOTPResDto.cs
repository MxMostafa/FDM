

namespace Client.Domain.Dtos.Response.Account;

public record ConfirmLoginWithOTPResDto(string   AccessToken,string RefreshToken,long ExpirationDuration);
