var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();
var app = builder.Build();
builder.Services.AddAutoMapper(typeof(Program)); //AutoMapper'� kullanabilmek i�in gerekli olan method. Program.cs dosyas�n� referans al�r.

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
