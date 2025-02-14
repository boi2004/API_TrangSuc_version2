using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using API_TrangSuc_vs2.Modules.Authentication.Models;  // Dùng các Model cho dữ liệu yêu cầu
using API_TrangSuc_vs2.Modules.Authentication.Services;
using API_TrangSuc_vs2.Modules.Authentication.Security;  // Dùng dịch vụ Login để kiểm tra người dùng

[Route("api/auth")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;  // Quản lý người dùng trong hệ thống
    private readonly SignInManager<IdentityUser> _signInManager;  // Quản lý đăng nhập và phiên làm việc của người dùng
    private readonly JwtHelper _jwtHelper;  // Sử dụng JwtHelper để tạo JWT Token

    public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, JwtHelper jwtHelper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtHelper = jwtHelper;
    }

    // API để đăng nhập và nhận JWT token
    [HttpPost("login")]  // Route cho API đăng nhập là /api/auth/login
    public async Task<IActionResult> Login([FromBody] LoginRequest model)
    {
        // Kiểm tra thông tin người dùng
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null || !(await _userManager.CheckPasswordAsync(user, model.Password)))  // Kiểm tra email và mật khẩu
            return Unauthorized();  // Nếu không hợp lệ, trả về lỗi Unauthorized

        var token = _jwtHelper.GenerateJwtToken(user);  // Nếu hợp lệ, tạo và trả về JWT token
        return Ok(value: new AuthResponse { Token = token });  // Trả về token cho người dùng
    }
}
