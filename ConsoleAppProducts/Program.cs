using ConsoleAppProducts;
using ConsoleAppProducts.Contexts;
using ConsoleAppProducts.Repositories;
using ConsoleAppProducts.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Weddutveckling\Datalagring\ConsoleAppProducts\ConsoleAppProducts\Data\ProductsDb.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<CategoryRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<ManufacturerRepository>();
    services.AddScoped<PriceListRepository>();
    services.AddScoped<DescriptionRepository>();

    services.AddScoped<ProductService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<ManufacturerService>();
    services.AddScoped<PriceListService>();
    services.AddScoped<DescriptionService>();

    services.AddSingleton<ConsoleUI>();

}).Build();

var consoleUI = builder.Services.GetRequiredService<ConsoleUI>();
consoleUI.ShowMainMenu();