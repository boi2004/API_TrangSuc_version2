using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using API_TrangSuc_vs2.Modules.Authentication.Services;
using API_TrangSuc_vs2.Modules.Authentication.Models;

[Route("api/auth")]
[ApiController]
public class ForgotPasswordController : ControllerBase
{
    private readonly ForgotPasswordService _forgotPasswordService;  // Dịch vụ xử lý quên mật khẩu

    public ForgotPasswordController(ForgotPasswordService forgotPasswordService)
    {
        _forgotPasswordService = forgotPasswordService;
    }

    // API để gửi yêu cầu đặt lại mật khẩu
    [HttpPost("forgotpassword")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest model)
    {
        // Gửi yêu cầu quên mật khẩu qua dịch vụ
        var resetToken = await _forgotPasswordService.GeneratePasswordResetTokenAsync(model.Email);

        if (resetToken == null)
            return BadRequest("Email không tồn tại trong hệ thống");

        return Ok(new { ResetToken = resetToken });  // Trả về token đặt lại mật khẩu
    }
}
