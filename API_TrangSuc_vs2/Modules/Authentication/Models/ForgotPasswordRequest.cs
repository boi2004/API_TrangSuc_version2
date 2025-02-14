using System.ComponentModel.DataAnnotations;

namespace API_TrangSuc_vs2.Modules.Authentication.Models
{
    public class ForgotPasswordRequest
    {
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }  // Email để gửi mã đặt lại mật khẩu
    }
}
