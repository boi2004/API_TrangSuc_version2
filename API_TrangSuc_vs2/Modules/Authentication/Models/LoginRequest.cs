using System.ComponentModel.DataAnnotations;

namespace API_TrangSuc_vs2.Modules.Authentication.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }  // Email của người dùng khi đăng nhập

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }  // Mật khẩu của người dùng khi đăng nhập
    }
}
