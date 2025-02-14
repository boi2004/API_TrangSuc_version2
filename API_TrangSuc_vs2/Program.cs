using Microsoft.EntityFrameworkCore;
using API_TrangSuc_vs2.Models;
using Microsoft.OpenApi.Models; // Thêm namespace này

var builder = WebApplication.CreateBuilder(args);

// Đăng ký dịch vụ Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Trang Sức",
        Version = "v1",
        Description = "API buôn bán và quản lý trang sức"
    });
});

var app = builder.Build();

// Kích hoạt Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
