using InnoTree.API.Extensions;
using InnoTree.Infrastructure.Extensions;
using InnoTree.Application.Extensions;
using InnoTree.API.Middlewares;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDbContext(builder);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureAutomapper();
builder.Services.ConfigureValidators();
builder.Services.ConfigureMediatr();
builder.Services.ConfigureCors();
builder.Services.ConfigureFastEndpoints();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseFastEndpoints()
	.UseSwaggerGen();

app.Run();
