using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using API_TrangSuc_vs2.Modules.Authentication.Controllers;

namespace API_TrangSuc_vs2.Modules.Authentication.Router
{
    public static class RegisterRoutes
    {
        public static IEndpointRouteBuilder MapRegisterRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/api/auth/register", async (RegisterController controller, RegisterRequest model) =>
            {
                return await controller.Register(model);
            })
            .WithName("Register")
            .Produces(200) // Trả về 200 nếu đăng ký thành công
            .Produces(400) // Trả về BadRequest nếu có lỗi
            .WithTags("Authentication");

            return endpoints;
        }
    }
}
