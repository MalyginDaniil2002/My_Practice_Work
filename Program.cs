using My_PracticeWork.Controllers;
using My_PracticeWork.Models;
using System.Text.RegularExpressions;
var builder = WebApplication.CreateBuilder();
var app = builder.Build();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=My_Controller}/{action=app}");
app.Run();