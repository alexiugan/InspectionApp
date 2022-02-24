using AutoMapper;
using InspectionApi.Data;
using InspectionApi.Interfaces;
using InspectionApi.Interfaces.Repositories;
using InspectionApi.Repositories;
using InspectionApi.Services;
using Microsoft.EntityFrameworkCore;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IInspectionRepository, InspectionRepository>();
builder.Services.AddTransient<IInspectionService, InspectionService>();

builder.Services.AddTransient<IInspectionTypeRepository, InspectionTypeRepository>();
builder.Services.AddTransient<IInspectionTypeService, InspectionTypeService>();

builder.Services.AddTransient<IStatusRepository, StatusRepository>();
builder.Services.AddTransient<IStatusService, StatusService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(myAllowSpecificOrigins, builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
