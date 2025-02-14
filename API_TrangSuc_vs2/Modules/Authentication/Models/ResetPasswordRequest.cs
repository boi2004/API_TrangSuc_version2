using System.ComponentModel.DataAnnotations;

namespace API_TrangSuc_vs2.Modules.Authentication.Models
{
    public class ResetPasswordRequest
    {
        [Required]
        public string Email { get; set; }  // Email của người dùng

        [Required]
        public string Token { get; set; }  // Token xác thực đặt lại mật khẩu

        [Required(ErrorMessage = "Mật khẩu mới không được để trống")]
        [MinLength(6, ErrorMessage = "Mật khẩu mới phải có ít nhất 6 ký tự")]
        public string NewPassword { get; set; }  // Mật khẩu mới

        [Required(ErrorMessage = "Xác nhận mật khẩu mới không được để trống")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string ConfirmNewPassword { get; set; }  // Xác nhận lại mật khẩu mới
    }
}
