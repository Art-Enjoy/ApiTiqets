
using ApiTiqets.IService;
using ApiTiqets.Service;
using Data;
using Logic.Ilogic;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<ISecurityLogic, SecurityLogic>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderLogic, OrderLogic>();
builder.Services.AddScoped<IProductLogic, ProductLogic>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IRolLogic, RolLogic>();
builder.Services.AddDbContext<ServiceContext>(
        options => options.UseSqlServer("name=ConnectionStrings:ServiceContext"));
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

app.Run();
