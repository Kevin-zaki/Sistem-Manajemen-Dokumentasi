using Microsoft.EntityFrameworkCore;
using latihan.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Tambahkan Controllers dengan Views
builder.Services.AddControllersWithViews();

// 2. Konfigurasi Database (MySQL)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 3. Konfigurasi Session (Penting untuk Login)
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Admin logout otomatis jika tidak aktif 30 menit
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = ".latihan.Session"; // Memberikan nama unik pada cookie
});

// Tambahkan akses HttpContext untuk memudahkan pengecekan session di View jika perlu
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// 4. Pengaturan Error Handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 5. URUTAN MIDDLEWARE (Sangat Penting!)
app.UseSession();        // 1. Session dulu
app.UseAuthentication(); // 2. Auth (Jika ada)
app.UseAuthorization();  // 3. Baru Authorization

// 6. Pemetaan Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();