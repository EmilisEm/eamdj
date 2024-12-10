using EAMDJ.Context;
using EAMDJ.Repository;
using EAMDJ.Repository.CategoryRepository;
using EAMDJ.Repository.OrderItemRepository;
using EAMDJ.Repository.OrderRepository;
using EAMDJ.Repository.ProductRepository;
using EAMDJ.Repository.UserRepository;
using EAMDJ.Service;
using EAMDJ.Service.CategoryService;
using EAMDJ.Service.OrderItemService;
using EAMDJ.Service.OrderService;
using EAMDJ.Service.ProductService;
using EAMDJ.Service.UserService;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ServiceAppContext>(options => options.UseNpgsql(connectionString)
	.UseLazyLoadingProxies());

builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();
builder.Services.AddScoped<IBusinessService, BusinessService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<ServiceAppContext>();

	var maxRetries = 5;
	var delayBetweenRetries = TimeSpan.FromSeconds(10);

	for (int attempt = 1; attempt <= maxRetries; attempt++)
	{
		try
		{
			Console.WriteLine($"Attempt {attempt} to apply migrations...");
			await dbContext.Database.MigrateAsync();
			Console.WriteLine("Migrations applied successfully.");
			break;
		}
		catch (NpgsqlException ex)
		{
			Console.WriteLine($"Database connection failed: {ex.Message}");

			if (attempt == maxRetries)
			{
				Console.WriteLine("Could not connect to the database after multiple attempts.");
				throw;
			}

			Console.WriteLine($"Retrying in {delayBetweenRetries.TotalSeconds} seconds...");
			System.Threading.Thread.Sleep(delayBetweenRetries);
		}
	}
}

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
