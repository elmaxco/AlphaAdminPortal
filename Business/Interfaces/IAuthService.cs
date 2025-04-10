using Business.Models;
using Microsoft.AspNetCore.Identity;

namespace Business.Interfaces;

public interface IAuthService
{
    Task<bool> LoginAsync(string email, string password, bool rememberMe = false);
    Task LogoutAsync();
    Task<IdentityResult> SignUpAsync(SignUpDto dto, string roleName = "User");
    Task<bool> UserExistsAsync(string email);
}
