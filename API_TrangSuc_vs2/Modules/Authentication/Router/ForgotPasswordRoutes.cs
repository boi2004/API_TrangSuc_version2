using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using API_TrangSuc_vs2.Modules.Authentication.Controllers;
using Microsoft.AspNetCore.Identity.Data;

namespace API_TrangSuc_vs2.Modules.Authentication.Router
{
    public static class ForgotPasswordRoutes
    {
        public static IEndpointRouteBuilder MapForgotPasswordRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/api/auth/forgotpassword", async (ForgotPasswordController controller, ForgotPasswordRequest model) =>
            {
                return await controller.ForgotPassword(model);
            })
            .WithName("ForgotPassword")
            .Produces(200) // Trả về 200 nếu yêu cầu quên mật khẩu thành công
            .Produces(400) // Trả về lỗi BadRequest nếu Email không tồn tại
            .WithTags("Authentication");

            return endpoints;
        }
    }
}
