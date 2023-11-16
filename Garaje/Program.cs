using BusinessLogicLayer.CarService;
using BusinessLogicLayer.Interfacaces;
using DateAccess.Data;
using DateAccess.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Garaje;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Garaje.ServiceCart;
using DateAccess.Interfaces;
using DateAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//формуємо рядок підключення
string connection = builder.Configuration.GetConnectionString("CarConnection") ?? throw new InvalidOperationException("Connection string 'WebAppLibraryContext' not found.");
//string connection = builder.Configuration.GetConnectionString("AzureConnection") ?? throw new InvalidOperationException("Connection string 'WebAppLibraryContext' not found.");


//підключення бази даних через рядок підключення
builder.Services.AddDbContext<CarajeDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CarajeDbContext>();


builder.Services.AddFluentValidationAutoValidation();

//builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

//Add sesssion
builder.Services.AddDistributedMemoryCache();

//����� ��� ���� ���
builder.Services.AddSession(options =>
{
    //������ ������ ���� ���������� � ������, � ���� ��������
    options.IdleTimeout = TimeSpan.FromSeconds(10000);
    options.Cookie.Name = "MyCar.Session";
    options.Cookie.HttpOnly = true; //���, �� ���������� ��� �볺������� ������� ��������
    options.Cookie.IsEssential = true; //��� �������� ��������� ��� ������ ����� ����������

});

//Підключаємо сервіси Iterface. Де воно зустрічає інтерфейс ICarService то функції для нього 
//бере з CarService
builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IStorageService, StorageService>();

builder.Services.AddScoped<IFileService, FileService>();

//додаємо Репозиторій
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//Add auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//спеціальний сервіс який додає інтерфейс Http для Cart
builder.Services.AddHttpContextAccessor();

//var servises = builder.Services;

var app = builder.Build();

//підключення сервісу з ролями
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    Seeder.SeedRoles(services).Wait();
    Seeder.SeedAdmin(services).Wait();
}

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

//перевіряє чи є в системі користувач
app.UseAuthentication();
//йде авторизація
app.UseAuthorization();

//AddSesion  ��� ���� �� �������� ���� ���� UseRouting() � UseHttpsRedirection()
app.UseSession();

//підключення рейзер пайдж пошти
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
