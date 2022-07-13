using System.Text.RegularExpressions;
List<Person> users = new List<Person>
{
    new() { },
};
var builder = WebApplication.CreateBuilder();
var app = builder.Build();
app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = request.Path;
    string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";
    if (path == "/api/users" && request.Method == "GET")
    {
        await Getting_People(response);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "GET")
    {
        string? id = path.Value?.Split("/")[3];
        await Getting_Person(id, response);
    }
    else if (path == "/api/users" && request.Method == "POST")
    {
        await Creating_Person(response, request);
    }
    else if (path == "/api/users" && request.Method == "PUT")
    {
        await Updating_Person(response, request);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "DELETE")
    {
        string? id = path.Value?.Split("/")[3];
        await Deleting_Person(id, response);
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("HTML_1.html");
    }
});
app.Run();
async Task Getting_People(HttpResponse response)
{
    await response.WriteAsJsonAsync(users);
}
async Task Error_1(HttpResponse response)
{
    response.StatusCode = 404;
    await response.WriteAsJsonAsync(new { message = "������������ �� ������" });
}
async Task Error_2(HttpResponse response)
{
    response.StatusCode = 400;
    await response.WriteAsJsonAsync(new { message = "������������ ������" });
}
async Task Getting_Person(string? id, HttpResponse response)
{
    Person? user = users.FirstOrDefault((u) => u.Id == id);
    if (user != null)
        await response.WriteAsJsonAsync(user);
    else
    {
        await Error_1(response);
    }
}
async Task Deleting_Person(string? id, HttpResponse response)
{
    Person? user = users.FirstOrDefault((u) => u.Id == id);
    if (user != null)
    {
        users.Remove(user);
    }
    else
    {
        await Error_1(response);
    }
}
async Task Creating_Person(HttpResponse response, HttpRequest request)
{
    try
    {
        var user = await request.ReadFromJsonAsync<Person>();
        if (user != null)
        {
            user.Id = Guid.NewGuid().ToString();
            users.Add(user);
        }
        else
        {
            throw new Exception("������������ ������");
        }
    }
    catch (Exception)
    {
        await Error_2(response);
    }
}
async Task Updating_Person(HttpResponse response, HttpRequest request)
{
    try
    {
        Person? userData = await request.ReadFromJsonAsync<Person>();
        if (userData != null)
        {
            var user = users.FirstOrDefault(u => u.Id == userData.Id);
            if (user != null)
            {
                user.Name = userData.Name;
                user.Surname = userData.Surname;
                user.Middle_Name = userData.Middle_Name;
                user.Birth_Year = userData.Birth_Year;
                user.Birth_Month = userData.Birth_Month;
                user.Birth_Day = userData.Birth_Day;
                await response.WriteAsJsonAsync(user);
            }
            else
            {
                await Error_1(response);
            }
        }
        else
        {
            throw new Exception("������������ ������");
        }
    }
    catch (Exception)
    {
        await Error_2(response);
    }
}
public class Person
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public string Middle_Name { get; set; } = "";
    public int Birth_Year { get; set; }
    public int Birth_Month { get; set; }
    public int Birth_Day { get; set; }
}