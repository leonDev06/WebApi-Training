using Sidekick.Training.Providers;
using Sidekick.Training.Providers.Sql;
using Sidekick.Training.Providers.Sql.Models;
using Sidekick.Training.Services;

var builder = WebApplication.CreateBuilder(args);

// ADD SERVICES TO THE CONTAINER
// Add the service as used by the UserService
builder.Services.AddScoped<IUserService, UserService>();
// Add the provider as used by the SQLUserProvider
builder.Services.AddScoped<IUserProvider, SqlUserProvider>();
// Add the SQL configuration
builder.Services.AddOptions<SqlConfig>().Bind(builder.Configuration.GetSection("SqlConfig"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
