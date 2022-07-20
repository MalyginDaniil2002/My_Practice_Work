using My_Practice_Work.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Users_Work>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}
app.UseHttpsRedirection();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=My_Controller_Users}/{action=Index}/{id?}");
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=My_Controller_Workers}/{action=Index}/{id?}");
app.Run();
