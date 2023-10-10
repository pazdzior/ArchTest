using StoreManager.Repository;
using StoreManager.Repository.Models;
using StoreManager.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IStoreManagerRepository, StoreManagerRepository>();
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.UseHttpsRedirection();
app.UseRouting();
    
app.MapGet("/", () => "Welcome to Store Manager App!");

app.Run();