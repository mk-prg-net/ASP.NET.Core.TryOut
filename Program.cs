using Microsoft.AspNetCore.Http.Extensions; 

var builder = WebApplication.CreateBuilder(
    new WebApplicationOptions{
        Args = args,
        ApplicationName = typeof(Program).Assembly.FullName,
        ContentRootPath = Directory.GetCurrentDirectory(),
        EnvironmentName = Environments.Staging,
        WebRootPath = "wwwroot"
    }
);

var app = builder.Build();

// Schaltet wwwroot und unterverzeichnisse frei
app.UseStaticFiles();


app.MapGet("/html", (HttpRequest req) => {

     var wwwroot = $"{req.Scheme}://{req.Host}";

     var content = string.Join('\n', System.IO.File.ReadAllLines(@".\wwwroot\index.html")).Replace("{☀}", wwwroot);

    return Results.Content(content, "text/html", System.Text.Encoding.UTF8);

});
app.MapGet("/", () => "Hello World!");

app.Run();
