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
builder.Services.AddScoped<IStaffDal,EfStaffDal>(); //IStaffDal'ý görünce EfStaffDal'ý kullan.
builder.Services.AddScoped<IStaffService, StaffManager>();

builder.Services.AddScoped<IServicesDal, EfServiceDal>(); //IStaffDal'ý görünce EfStaffDal'ý kullan.
builder.Services.AddScoped<IServiceService, ServiceManager>();

builder.Services.AddScoped<IRoomDal, EfRoomDal>(); //IStaffDal'ý görünce EfStaffDal'ý kullan.
builder.Services.AddScoped<IRoomService, RoomManager>();

builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>(); //IStaffDal'ý görünce EfStaffDal'ý kullan.
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>(); //IStaffDal'ý görünce EfStaffDal'ý kullan.
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
//consume iþlemleri için gerekli olan CORS ayarlarý yapýldý.
builder.Services.AddCors //api iþlemlerinde baþka kaynaklar tarafýndan tüketilmesini saðlayan method.
    (options =>
    {
        options.AddPolicy("OtelApiCors", //bir policy oluþturduk.
            builder =>
            {
                builder.AllowAnyOrigin() //herhangi bir kaynaða izin ver.
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
app.UseCors("OtelApiCors"); //oluþturduðumuz policy'i kullanýyoruz. UseAuthorization'ýn üstüne yazýlýr.
app.UseAuthorization();

app.MapControllers();

app.Run();
