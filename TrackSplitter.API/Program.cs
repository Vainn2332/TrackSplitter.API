using TrackSplitter.API.Configuration;
using TrackSplitter.API.Extensions;
using TrackSplitter.DataAccess.Extensions;

EnvLoader.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddAppServices(builder.Configuration);

var app = builder.Build();

await app.Services.MigrateDatabaseAsync();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
