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

app.UseRouting();

// �ҥ� Session �����n��
app.UseSession(); // �����b app.UseAuthorization() ���e

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Member}/{action=Index}/{id?}");

app.Run();
