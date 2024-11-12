using Big_Project_v3.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// �K�[�A�Ȩ� DI �e��
builder.Services.AddDbContext<ITableDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("iTableDBConnection")));
// �]�w�ϥ� SQL Server �� iTableDbContext�A�s���r��q appsettings.json ���� iTableDBConnection Ū��

builder.Services.AddControllersWithViews(); // ���U MVC �A��

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SearchPage}/{action=Index}/{id?}");

app.Run();
