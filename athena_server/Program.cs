using Microsoft.EntityFrameworkCore;
using athena_server;
using athena_server.Services;
using athena_server.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IWikiService, WikiService>();
builder.Services.AddScoped<IWikiRepository, WikiRepository>();

builder.Services.AddDbContext<AthenaDbContext>(db =>
    db.UseSqlServer(builder.Configuration.GetConnectionString("AthenaDbConnectionString")), ServiceLifetime.Scoped);


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

app.UseCors("CorsApi");

app.UseAuthorization();

app.MapControllers();

app.Run();
