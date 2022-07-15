using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using My_PracticeWork.Models;
using Microsoft.AspNetCore.Mvc;
using My_PracticeWork.Controllers;
using System.Text.RegularExpressions;
var builder = WebApplication.CreateBuilder();
var app = builder.Build();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=My_Controller}/{action=app}");
app.Run();