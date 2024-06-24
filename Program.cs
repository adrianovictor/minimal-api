using Microsoft.EntityFrameworkCore;
using minimal_api.Infrastructure.DataContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MinimalApiDbContext>(options => {
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
