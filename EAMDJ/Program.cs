using EAMDJ.Context;
using EAMDJ.Repository;
using EAMDJ.Repository.CategoryRepository;
using EAMDJ.Repository.DiscountRepository;
using EAMDJ.Repository.OrderItemRepository;
using EAMDJ.Repository.OrderRepository;
using EAMDJ.Repository.ProductModifierRepository;
using EAMDJ.Repository.ProductRepository;
using EAMDJ.Repository.ReservationRepository;
using EAMDJ.Repository.ServiceTimeRepository;
using EAMDJ.Repository.TaxRepository;
using EAMDJ.Repository.UserRepository;
using EAMDJ.Service.BusinessService.BusinessService;
using EAMDJ.Service.CategoryService;
using EAMDJ.Service.DiscountService;
using EAMDJ.Service.OrderItemService;
using EAMDJ.Service.OrderService;
using EAMDJ.Service.ProductModifierService;
using EAMDJ.Service.ProductService;
using EAMDJ.Service.ReservationService;
using EAMDJ.Service.ServiceTimeService;
using EAMDJ.Service.TaxService;
using EAMDJ.Service.UserService;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using JwtBearerDefaults = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin",
	policy => policy.WithOrigins("http://localhost:3000")
	.AllowAnyHeader()
	.AllowAnyMethod()
	.AllowCredentials());
});

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

builder.Services.AddScoped<IProductModifierRepository, ProductModifierRepository>();
builder.Services.AddScoped<IProductModifierService, ProductModifierService>();

builder.Services.AddScoped<ITaxRepository, TaxRepository>();
builder.Services.AddScoped<ITaxService, TaxService>();

builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IDiscountService, DiscountService>();

builder.Services.AddScoped<IServiceTimeRepository, ServiceTimeRepository>();
builder.Services.AddScoped<IServiceTimeService, ServiceTimeService>();

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your valid token in the text input below.\n\nExample: abc123xyz",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("User", policy => policy.RequireRole("User"));
});

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

app.UseCors("AllowSpecificOrigin");

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
