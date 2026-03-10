using FluentValidation;
using FluentValidation.AspNetCore;
using LinkForge.Infrastructure.Data;
using LinkForge.Infrastructure.Repositories;
using LinkForge.Application.Interfaces;
using LinkForge.Application.Mappings;
using LinkForge.Application.Services;
using LinkForge.Application.Validators;
using LinkForge.Domain.Entities;
using LinkForge.Web.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("mariadb");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

builder.Services.AddScoped<ILinkRepository, LinkRepository>();
builder.Services.AddScoped<LinkService>();
builder.Services.AddAutoMapper(typeof(ShortLinkProfile).Assembly);

builder.Services.AddControllersWithViews();
builder.Services.AddValidatorsFromAssemblyContaining<CreateLinkRequestValidator>();

var app = builder.Build();
app.UseGlobalExceptionMiddleware();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Link}/{action=Index}/{id?}");

app.Run();