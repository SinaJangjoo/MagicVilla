using MagicVillaAPI;
using MagicVillaAPI.Data;
using MagicVillaAPI.Repository;
using MagicVillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var key = builder.Configuration.GetValue<string>("APISettings:secretkey");
// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<IVillaRepository, VillaRepository>();
builder.Services.AddScoped<IVillaNumberRepository, VillaNumberRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddApiVersioning(options =>
//{
//	options.AssumeDefaultVersionWhenUnspecified=true;
//	options.DefaultApiVersion = new ApiVersion(1, 0);
//});
builder.Services.AddResponseCaching();

//builder.Services.AddScoped<IRepository,Repository>();
builder.Services.AddDbContext<MagicVillaDB>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
	x.RequireHttpsMetadata = false;
	x.SaveToken = true;
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
		ValidateIssuer = false,
		ValidateAudience = false
	};
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description =
			"JWT Authorization header using the Bearer scheme. \r\n\r\n " +
			"Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
			"Example: \"Bearer 12345abcdef\"",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Scheme = "Bearer"
	});
	options.AddSecurityRequirement(new OpenApiSecurityRequirement()
{
	{
		new OpenApiSecurityScheme
		{
			Reference = new OpenApiReference
			{
				Type = ReferenceType.SecurityScheme,
				Id = "Bearer"
			},
			Scheme = "oauth2",
			Name = "Bearer",
			In = ParameterLocation.Header
		},
		new List<string>()
	}
});
});
builder.Services.AddControllers(options =>
{
	options.CacheProfiles.Add("default30", new CacheProfile
	{
		Duration = 30,
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
