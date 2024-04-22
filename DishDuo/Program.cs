using DishDuo.ContextDBConfig;
using DishDuo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DishDuo.Repository;

var builder = WebApplication.CreateBuilder(args);
var dbconnection = builder.Configuration.GetConnectionString("dbConnection");

// JB Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DishDuoDBContext>(options => 
options.UseSqlServer(dbconnection));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DishDuoDBContext>();

builder.Services.AddTransient<IData, Data>();

var app = builder.Build();


//JB Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    //JB The default HSTS value is 30 days.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
