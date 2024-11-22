using Client.Domain.Dtos.Request.Account;
using Client.Domain.Dtos.Response.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Application.Services
{
    public class AccountService : IAccountService
    {
        public Task<ApiResponse<ConfirmLoginWithOTPResDto>> ConfirmLoginWithOTPAsync(ConfirmLoginWithOTPReqDto confirmLoginWithOTPReqDto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<LoginWithOTPResDto>> LoginWithOTPAsync(LoginWithOTPReqDto loginWithOTPResDto)
        {
            throw new NotImplementedException();
        }
    }
}
