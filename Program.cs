using HastaneAppv4.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<HastaneContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HastaneConnection")));


builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<HastaneContext>()
.AddDefaultUI(); 


builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HastaneAppv4.Data.HastaneContext>();

    if (!context.Doktorlar.Any())
    {
        context.Doktorlar.AddRange(
            new HastaneAppv4.Models.Doktor { Ad = "Furkan", Soyad = "Köse", Brans = "Genel Cerrahi" },
            new HastaneAppv4.Models.Doktor { Ad = "Ayþe", Soyad = "Demir", Brans = "Nöroloji" },
            new HastaneAppv4.Models.Doktor { Ad = "Ahmet", Soyad = "Yýlmaz", Brans = "Kardiyoloji" }
        );
        context.SaveChanges();
    }
}

app.Run();