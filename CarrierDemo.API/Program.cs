using CarrierDemo.API.Filters;
using CarrierDemo.BLL;
using CarrierDemo.BLL.Jobs;
using CarrierDemo.BLL.Mapping;
using CarrierDemo.DAL.Context;
using CarrierDemo.DAL.Repositories.Concrete;
using CarrierDemo.DAL.Repositories.Interface;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt => opt.Filters.Add<ErrorHandlingFiltetAttribute>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injections
builder.Services.AddScoped<ICarrierReadRepository, CarrierReadRepository>();
builder.Services.AddScoped<ICarrierWriteRepository, CarrierWriteRepository>();
builder.Services.AddScoped<ICarrierConfigurationReadRepository, CarrierConfigurationReadRepository>();
builder.Services.AddScoped<ICarrierConfigurationWriteRepository, CarrierConfigurationWriteRepository>();
builder.Services.AddScoped<IOrderReadRepository, OrderReadRepository>();
builder.Services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
builder.Services.AddScoped<ICarrierReportWriteRepository, CarrierReportWriteRepostiory>();

builder.Services.AddScoped<ICarrierService, CarrierService>();
builder.Services.AddScoped<ICarrierConfigurationService, CarrierConfigurationService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddAutoMapper(typeof(MapProfile));

// Connect to Db
builder.Services.AddDbContext<CarrierDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("db")));

// Hangfire Job
builder.Services.AddHangfire(opt =>
{
    opt.UseSqlServerStorage(builder.Configuration.GetConnectionString("db"));
    RecurringJob.AddOrUpdate<Job>(j => j.ReportOrders(), "0 * * * *");
});
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHangfireDashboard();

app.MapControllers();

app.Run();
