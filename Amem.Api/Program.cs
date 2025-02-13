using Amem.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.AddControllers();
builder.Services.CorsConfig();
builder.PostgresDatabaseConfig();
builder.LoadDependencyInjection();
builder.SwaggerConfig();

var app = builder.Build();
app.ScalarConfig();
app.HttpRequestPipelineConfig();
app.UseHttpsRedirection();

app.Run();
