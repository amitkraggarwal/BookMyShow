using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Hosting;

//creates the builder object.
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
//adds support for API controllers 
builder.Services.AddControllers();

//Register services (DI)
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IShowRepository, ShowRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IShowSeatRepository, ShowSeatRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPricingCalculator, PricingCalculator>();
builder.Services.AddScoped<IPricingCalculator, PricingCalculator>();
builder.Services.AddScoped<IShowSeatTypeRepository, ShowSeatTypeRepository>();
//Optional: Add Swagger for API documentation


var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(config.GetConnectionString("DefaultConnection")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure middleware
//using Microsoft.Extensions.Hosting;

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Middleware pipeline for routing and authorization
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseRouting();

// This maps the controller actions to the endpoints, allowing them to handle incoming HTTP requests. 
//It is essential for enabling the functionality of your API controllers. 
app.MapControllers(); 

/*
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "api/{controller=User}/{action=index}/{id?}");
});
*/   

app.Run();
