using EmployeeApi.Business.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EmployeeApi.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Register all custom services
builder.Services.ConfigureServices();

//Configure the db
builder.Services.ConfigureDb(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews(config => 
    config.Filters.Add(typeof(ExceptionHandlingFilter)));

//Cross Origin Resource Sharing settings
builder.Services.ConfigureCors();

//Configure Serilog logging
builder.ConfigureLogging();

var app = builder.Build();

//Configure all custom middleware
app.UseExceptionMiddleware();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
