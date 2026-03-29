using HogRider.Backend.Data;
using HogRider.Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// 🌍 PORT (Render + local)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

// 📦 Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🌐 CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// 🗄️ DB
var connectionString =
    Environment.GetEnvironmentVariable("DB_CONNECTION")
    ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 34))
    )
);

// 🔌 DI
builder.Services.AddScoped<IDishService, DishService>();

var app = builder.Build();

// ✅ VERY IMPORTANT for Render (proxy)
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

// 🌐 Middleware order
app.UseCors("AllowAll");

// 🔥 Swagger (visada įjungtas)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HogRider API");
    c.RoutePrefix = "swagger";
});

// 🔐 Auth
app.UseAuthorization();

// 🎯 Controllers
app.MapControllers();

// ✅ Debug endpoint (labai padeda)
app.MapGet("/", () => "API is running");

// ❗ Migrate TIK lokaliai
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
    }
}

app.Run();