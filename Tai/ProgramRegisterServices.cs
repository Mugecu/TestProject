using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tai.Authentications.Infrastucture;
using Tai.Programs.Infrastructure;

namespace Tai
{
    public partial class Program
    {
        public static void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TaiUserDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("SqLite"));
            });
            builder.Services.AddDbContext<TaiProgrammDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("SqLite"));
            });

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                });
        }
    }
}
