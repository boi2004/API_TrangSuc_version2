using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using API_TrangSuc_vs2.Modules.Authentication.Controllers;
using Driver_Company_5._0.Modules.Authentication.Models;

namespace API_TrangSuc_vs2.Modules.Authentication.Router
{
    public static class LoginRoutes
    {
        // Phương thức mở rộng để định nghĩa các route liên quan đến Đăng nhập
        public static IEndpointRouteBuilder MapLoginRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/api/auth/login", async (LoginController controller, LoginRequest model) =>
            {
                return await controller.Login(model);
            })
            .WithName("Login")
            .Produces<AuthResponse>(200) // Định nghĩa kiểu dữ liệu trả về (JWT Token)
            .Produces(401) // Trả về Unauthorized nếu đăng nhập thất bại
            .WithTags("Authentication"); // Nhóm API này vào nhóm Authentication trong Swagger

            return endpoints;
        }
    }
}
