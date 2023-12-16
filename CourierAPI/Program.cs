using CourierAPI.Helpers;
using CourierAPI.Logic;
using CourierAPI.Models;
using CourierAPI.Services;
using CourierAPI.Services.Converters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IInquiryRepository, InquiryRepository>();
builder.Services.AddScoped<IInquiriesLogic,  InquiriesLogic>();
builder.Services.AddScoped<IInquiryModelToDtoConverter, InquiryModelToDtoConverter>();
builder.Services.AddScoped<ICourierRepository, CourierRepository>();
builder.Services.AddControllers();
builder.Services.AddDbContext<DeliverymanCastingDbContext>(o => 
o.UseSqlServer(builder.Configuration.GetConnectionString("DeliverymanCastingDbConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Seed();

app.Run();
