using AutoMapper;
using Domain.Models;
using Microsoft.AspNet.Identity;

using Services.DTOs.Account;
using Services.Helpers;
using Services.Services.Interfaces;


namespace Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public AccountService(UserManager<AppUser> userManager,
                              RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> roleManager,
                              IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<RegisterResponse> SignUpAsync(RegisterDto model)
        {
            if (model is null) throw new ArgumentNullException("Data is not found");
           AppUser user = _mapper.Map<AppUser>(model);
           IdentityResult result =  await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return new RegisterResponse
                {
                    StatusMessage = "Failed",
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }
            return new RegisterResponse { Errors = null, StatusMessage = "Success" };
        }
    }
}
