using HastaneAppv4.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlantýsý
builder.Services.AddDbContext<HastaneContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HastaneConnection")));

// Identity servisleri (GÜNCELLENMÝÞ HALÝ)
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<HastaneContext>()
.AddDefaultUI(); // Bu satýrý ekleyin

// Diðer servisler
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Pipeline konfigürasyonu
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // ÖNEMLÝ: Bu satýr mutlaka olmalý
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();