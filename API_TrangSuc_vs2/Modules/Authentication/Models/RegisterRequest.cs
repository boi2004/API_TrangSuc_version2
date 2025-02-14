using System.ComponentModel.DataAnnotations;

namespace API_TrangSuc_vs2.Modules.Authentication.Models
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }  // Email của người dùng

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string Password { get; set; }  // Mật khẩu người dùng

        [Required(ErrorMessage = "Xác nhận mật khẩu không được để trống")]
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string ConfirmPassword { get; set; }  // Xác nhận lại mật khẩu

        public string FullName { get; set; }  // Họ và tên người dùng
        public string Address { get; set; }  // Địa chỉ người dùng
    }
}
