using ClassLibrary1.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var build = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\EC\DATALAGRING\00\ClassLibrary1\ClassLibrary1\Data\local_database.mdf;Integrated Security=True;Connect Timeout=30"));

}).Build(); 
