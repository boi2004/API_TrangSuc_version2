using Microsoft.AspNetCore.Identity;
using API_TrangSuc_vs2.Modules.Authentication.Models;

namespace API_TrangSuc_vs2.Modules.Authentication.Services
{
    public class RegisterService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // Đăng ký người dùng mới
        public async Task<IdentityResult> RegisterUser(RegisterRequest model)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            return await _userManager.CreateAsync(user, model.Password);  // Thực hiện tạo người dùng mới với mật khẩu
        }
    }
}
