using Big_Project_v3.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// �K�[�A�Ȩ� DI �e��
builder.Services.AddDbContext<ITableDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("iTableDBConnection"));
});
// �]�w�ϥ� SQL Server �� iTableDbContext�A�s���r��q appsettings.json ���� iTableDBConnection Ū��

builder.Services.AddControllersWithViews(); // ���U MVC �A��

// �t�m Session �䴩
builder.Services.AddDistributedMemoryCache(); // �K�[���s�w�s�]Session ����¦�s�x�^
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // �]�m Session ���L���ɶ�
    options.Cookie.HttpOnly = true; // �u��q�L HTTP �X�� Session
    options.Cookie.IsEssential = true; // �аO�����ݪ� Cookie
});

builder.Services.AddHttpContextAccessor(); // �K�[ HttpContextAccessor �䴩�A��K�b������X�� HttpContext

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.Use(async (context, next) =>
{
    // �j��]�m Content-Type �� UTF-8�A�קK�ýX
    context.Response.Headers.Append("Content-Type", "text/html; charset=UTF-8");
    await next.Invoke();
});

app.UseRouting();

// �ҥ� Session �����n��
app.UseSession(); // �����b app.UseAuthorization() ���e

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "home",
//    pattern: "{controller=HomePage}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "booking",
//    pattern: "{controller=Booking}/{action=BookingPage}/{restaurantID?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action}/{id?}");

//app.MapControllerRoute(
//    name: "booking",
//    pattern: "Booking/{action=BookingPage}/{RestaurantId?}",
//    defaults: new { controller = "Booking" });

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=HomePage}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomePage}/{action=Index}/{id?}");


// �ҥ��ݩʸ���
app.MapControllers();

app.Run();
