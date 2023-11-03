using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VisionOne.DAL.Data;
using VisionOne.DAL.Repository;
using VisionOne.DAL.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
//builder.Services.AddTransient<IUserRepository, UserRepository>();


//DI 
builder.Services.AddDbContext<VisionOneDataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("VisionOneDB")));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
