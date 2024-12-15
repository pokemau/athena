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
builder.Services.AddScoped<UserService>();

builder.Services.AddDbContext<AthenaDbContext>(db =>
    db.UseSqlServer(builder.Configuration.GetConnectionString("AthenaDbConnectionString")), ServiceLifetime.Scoped);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;               
    options.Password.RequireLowercase = false;           
    options.Password.RequireUppercase = false;           
    options.Password.RequireNonAlphanumeric = false;     
    options.Password.RequiredLength = 2;                  
})
    .AddEntityFrameworkStores<AthenaDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";  
    options.AccessDeniedPath = "/Account/AccessDenied";  
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
