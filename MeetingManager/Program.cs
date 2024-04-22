using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MeetingManager.Data;
using MeetingManager.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;



var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MeetingDbContextConnection") ?? throw new InvalidOperationException("Connection string 'MeetingDbContextConnection' not found.");

builder.Services.AddDbContext<MeetingDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MeetingDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

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
app.MapRazorPages();
app.Run();
