

namespace Client.Domain.Dtos.Request.Account
{
    public record ConfirmLoginWithOTPReqDto(string PhoneNumber,string Code);
}
