using Services.DTOs.Account;
using Services.Helpers;


namespace Services.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<RegisterResponse> SignUpAsync(RegisterDto model);
    }
}
