using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tai.Apis;
using Tai.Authentications.Infrastucture;
using Tai.Authentications.Interfaces;
using Tai.Authentications.Services;
using Tai.Programs.Infrastructure;

namespace Tai
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddNewtonsoftJson();

            RegisterServices(builder);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region AddAuthServices
            AddAuthenticationServices(builder);
            AddRepositories(builder);
            AddDateTimeService(builder);
            #endregion

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                using var scope = app.Services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<TaiUserDbContext>();
                var programmDb = scope.ServiceProvider.GetRequiredService<TaiProgrammDbContext>();

                db.Database.EnsureCreated();
                db.Database.EnsureCreated();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            #region Login Section
            app.AddLoginMaps();
            #endregion

            #region User Section with DateTimeService
            using var dateTimeServiceScope = app.Services.CreateScope();
            var dateTimeService = dateTimeServiceScope.ServiceProvider.GetRequiredService<IDateTime>();
            new UserApi(dateTimeService).Register(app);
            #endregion

            #region TaiProgramm Controller
            new TaiProgrammApi().Register(app);
            #endregion

            app.Run();
        }
    }
}