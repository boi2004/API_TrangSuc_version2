using Microsoft.AspNetCore.Identity;

namespace API_TrangSuc_vs2.Modules.Authentication.Security
{
    public class PasswordHasher
    {
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;

        public PasswordHasher(IPasswordHasher<IdentityUser> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string HashPassword(IdentityUser user, string password)
        {
            return _passwordHasher.HashPassword(user, password);  // Mã hóa mật khẩu trước khi lưu
        }
    }
}
