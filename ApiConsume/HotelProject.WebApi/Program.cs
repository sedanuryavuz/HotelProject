using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//DbContext
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IStaffDal,EfStaffDal>(); //IStaffDal'� g�r�nce EfStaffDal'� kullan.
builder.Services.AddScoped<IStaffService, StaffManager>();

builder.Services.AddScoped<IServicesDal, EfServiceDal>(); //IStaffDal'� g�r�nce EfStaffDal'� kullan.
builder.Services.AddScoped<IServiceService, ServiceManager>();

builder.Services.AddScoped<IRoomDal, EfRoomDal>(); //IStaffDal'� g�r�nce EfStaffDal'� kullan.
builder.Services.AddScoped<IRoomService, RoomManager>();

builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>(); //IStaffDal'� g�r�nce EfStaffDal'� kullan.
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>(); //IStaffDal'� g�r�nce EfStaffDal'� kullan.
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
//consume i�lemleri i�in gerekli olan CORS ayarlar� yap�ld�.
builder.Services.AddCors //api i�lemlerinde ba�ka kaynaklar taraf�ndan t�ketilmesini sa�layan method.
    (options =>
    {
        options.AddPolicy("OtelApiCors", //bir policy olu�turduk.
            builder =>
            {
                builder.AllowAnyOrigin() //herhangi bir kayna�a izin ver.
                    .AllowAnyMethod() //herhangi bir methoda izin ver.
                    .AllowAnyHeader(); //herhangi bir header'a izin ver.
            });
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("OtelApiCors"); //olu�turdu�umuz policy'i kullan�yoruz. UseAuthorization'�n �st�ne yaz�l�r.
app.UseAuthorization();

app.MapControllers();

app.Run();
