using Backend.Mappings;
using Backend.Services;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped(provider => new NpgsqlConnection(builder.Configuration.GetConnectionString("db")));

builder.Services.AddScoped<CostumerService>();

builder.Services.AddAutoMapper(typeof(ModelToDTOMappingProfile));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
