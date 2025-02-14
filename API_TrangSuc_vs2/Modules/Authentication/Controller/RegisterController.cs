using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using API_TrangSuc_vs2.Modules.Authentication.Models;  // Đưa các Models vào để truyền tham số vào API
using API_TrangSuc_vs2.Modules.Authentication.Services;  // Sử dụng các Service giúp xử lý logic đăng ký

// Định nghĩa route cho Controller này
[Route("api/auth")]
[ApiController]
public class RegisterController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;  // Đảm bảo người dùng được quản lý và lưu trữ
    private readonly RegisterService _registerService;  // Sử dụng RegisterService để xử lý logic đăng ký

    public RegisterController(UserManager<IdentityUser> userManager, RegisterService registerService)
    {
        _userManager = userManager;
        _registerService = registerService;
    }

    // API cho chức năng đăng ký tài khoản mới
    [HttpPost("register")]  // Route sẽ là /api/auth/register
    public async Task<IActionResult> Register([FromBody] RegisterRequest model)
    {
        // Sử dụng RegisterService để đăng ký người dùng
        var result = await _registerService.RegisterUser(model);

        if (!result.Succeeded)
            return BadRequest(result.Errors);  // Trả về lỗi nếu đăng ký không thành công

        return Ok(new { Message = "Đăng ký thành công!" });  // Trả về thông báo thành công
    }
}
