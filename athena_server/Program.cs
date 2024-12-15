using Microsoft.EntityFrameworkCore;
using athena_server;
using athena_server.Services;
using athena_server.Repositories;
using athena_server.Repositories.Interfaces;
using athena_server.Services.Interfaces;
using athena_server.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IWikiService, WikiService>();
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddScoped<IWikiRepository, WikiRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<AccountService>();

builder.Services.AddDbContext<AthenaDbContext>(db =>
    db.UseSqlServer(builder.Configuration.GetConnectionString("AthenaDbConnectionString")), ServiceLifetime.Scoped);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;               // No digit required
    options.Password.RequireLowercase = false;           // No lowercase letter required
    options.Password.RequireUppercase = false;           // No uppercase letter required
    options.Password.RequireNonAlphanumeric = false;     // No special characters required
    options.Password.RequiredLength = 2;                  // You can set a minimum length if needed
})
    .AddEntityFrameworkStores<AthenaDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";  // Specify your login path
    options.AccessDeniedPath = "/Account/AccessDenied";  // Specify access denied path
});


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder =>
        builder.WithOrigins("http://localhost:5173")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS globally
app.UseCors("AllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
