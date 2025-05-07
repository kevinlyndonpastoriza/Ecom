using Web.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppDI(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
