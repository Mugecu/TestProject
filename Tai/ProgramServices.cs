using Common.Entities;
using Tai.Authentications.Entities;
using Tai.Authentications.Infrastructure.Repositories;
using Tai.Authentications.Interfaces;
using Tai.Authentications.Services;
using Tai.Programs.Infrastructure.Repositories;
using TaiProgramms.Entities;

namespace Tai
{
    public static partial class Program
    {
        private static WebApplicationBuilder? AddAuthenticationServices(this WebApplicationBuilder? builder)
        {
            builder?.Services?.AddScoped<ITokenService, TokenService>();

            return builder;
        }

        private static WebApplicationBuilder? AddRepositories(this WebApplicationBuilder? builder)
        {
            builder?.Services?.AddScoped<Repository<User>, UserRepository>();
            builder?.Services?.AddScoped<Repository<TaiProgramm>, TaiProgrammRepository>();

            return builder;
        }

        private static WebApplicationBuilder? AddDateTimeService(this WebApplicationBuilder? builder)
        {
            builder?.Services?.AddScoped<IDateTime, DateTimeService>();
            return builder;
        }
    }
}
