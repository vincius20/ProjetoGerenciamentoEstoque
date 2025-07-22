using Entities;
using Microsoft.EntityFrameworkCore;
using Services;
using ServicesContracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<ISalesRecordsService, SalesRecordsService>();
builder.Services.AddScoped<ISellersService, SellersService>();


string connectionString = builder.Configuration.GetConnectionString("MySQL");

builder.Services.AddDbContext<StockDbContext>(option =>
{
    option.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
