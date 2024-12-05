using Application.MappingSetup;
using Application.Services;
using AspNetCoreHero.ToastNotification;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<QuanLyHieuSachNhaNamContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"))
    .EnableSensitiveDataLogging());

builder.Services.AddDomainMappings();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 7; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ISachRepository, SachRepository>();

builder.Services.AddScoped<ISachService, SachService>();

var app = builder.Build();

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
