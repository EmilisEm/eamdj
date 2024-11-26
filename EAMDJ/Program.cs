using EAMDJ.Context;
using EAMDJ.Repository;
using EAMDJ.Service;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using JwtBearerDefaults = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ServiceAppContext>(options => options.UseNpgsql(connectionString)
	.UseLazyLoadingProxies());

builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();
builder.Services.AddScoped<IBusinessService, BusinessService>();

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

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
