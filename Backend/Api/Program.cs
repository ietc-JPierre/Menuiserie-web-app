using Api.EndPoints;
using Api.Middleware;
using Core;
using Infrastructure;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddCoreServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
        ),

        RoleClaimType = ClaimTypes.Role
    };
});

builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
DatabaseInitializer.Initialize(connectionString!);

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseCors("AllowLocalhost");
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

#region Endpoints

app.MapAuthRoutes();

app.MapClientRoutes();
app.MapTypeClientRoutes();
app.MapCategorieRoutes();
app.MapProduitRoutes();
app.MapDimensionRoutes();
app.MapPersonnelRoutes();
app.MapCodePostalChantierRoutes();
app.MapChantierRoutes();
app.MapCommandeRoutes();
app.MapClientChantierRoutes();
app.MapPersonnelCommandeRoutes();
app.MapCommandeProduitRoutes();

#endregion

app.Run();