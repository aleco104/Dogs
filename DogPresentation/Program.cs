using ClassLibrary1.Contexts;
using ClassLibrary1.Repositories;
using ClassLibrary1.Services;
using DogPresentation.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var build = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\EC\DATALAGRING\00\ClassLibrary1\ClassLibrary1\Data\local_database.mdf;Integrated Security=True;Connect Timeout=30"));
    services.AddScoped<AddressRepository>();
    services.AddScoped<BreedRepository>();
    services.AddScoped<ColorRepository>();
    services.AddScoped<DogRepository>();
    services.AddScoped<KennelRepository>();
    services.AddScoped<OwnerRepository>();
    services.AddScoped<MenuService>();
    services.AddScoped<OwnerService>();
    services.AddScoped<DogService>();



}).Build();

var menuService = build.Services.GetRequiredService<MenuService>();
menuService.MainMenu();