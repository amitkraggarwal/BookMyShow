using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
public class Program
{
    public static void Main(string[] args)
    {
        // Your application entry point
    }
}
/*

var services = new ServiceCollection();
services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(config.GetConnectionString("DefaultConnection")));

var serviceProvider = services.BuildServiceProvider();
using (var context = serviceProvider.GetRequiredService<AppDbContext>())
{
    // Perform database operations using the context
}
*/

/*
var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseMySQL(config.GetConnectionString("DefaultConnection"))
    .Options;
using (var context = new AppDbContext(options))
{
    // Perform database operations using the context
}
*/