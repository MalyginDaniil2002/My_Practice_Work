var builder = WebApplication.CreateBuilder();
var app = builder.Build();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=My_Controller}/{action=Index}/{id?}");
app.Run();