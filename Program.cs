using Microsoft.EntityFrameworkCore;
using ProvaPub.Repositories;
using ProvaPub.Repositories.Interfaces;
using ProvaPub.Repository;
using ProvaPub.Services;
using ProvaPub.Services.Interfaces;
using ProvaPub.TypesOfPayments;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TestDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("ctx")));

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IPaginationService, PaginationService>();
builder.Services.AddTransient<IBaseRepository, BaseRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IPaymentProcessor, PixPaymentProcessor>();
builder.Services.AddTransient<IPaymentProcessor, CreditCardPaymentProcessor>();
builder.Services.AddTransient<IPaymentProcessor, PayPalPaymentProcessor>();

builder.Services.AddSingleton<RandomService>();
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
