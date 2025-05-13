using Web.Extension;
using Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppDI(builder.Configuration);

var app = builder.Build();

app.MapEndpoints();

app.Run();
