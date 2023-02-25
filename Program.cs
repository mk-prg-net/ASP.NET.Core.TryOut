using Microsoft.AspNetCore.Http.Extensions;
// Martin Korneffel, Feb.2023
// SPA- Grundgerüst auf Basis von minimal WebApi entwickeln

// Konfigurieren des Builders
var builder = WebApplication.CreateBuilder(
    new WebApplicationOptions
    {
        Args = args,
        ApplicationName = typeof(Program).Assembly.FullName,
        ContentRootPath = Directory.GetCurrentDirectory(),
        EnvironmentName = Environments.Staging,

        // Hier wird das Wurzelverzeichnis für den statischen Content definiert (html, css, scripte)
        WebRootPath = "wwwroot"  
    }
); 

// Alle Dienste konfigurieren, welche die Anwendung nutzt

var app = builder.Build();

// Schaltet wwwroot und unterverzeichnisse frei
app.UseStaticFiles();

// Startup der SPA- Applikation: Hier wird das initiale HTML- Dokument geladen
app.MapGet("/html", (HttpRequest req) =>
{
    // Origin des statischen Content bestimmen
    var wwwroot = $"{req.Scheme}://{req.Host}";

    // Alle {☀} oOrigin Symbole mit der Root ersetzen in der HTML- Datei
    var content = string.Join('\n', System.IO.File.ReadAllLines(@".\wwwroot\index.html")).Replace("{☀}", wwwroot);

    return Results.Content(content, "text/html", System.Text.Encoding.UTF8);

});


app.MapGet("/", () => "Hello World!");

app.Run();
