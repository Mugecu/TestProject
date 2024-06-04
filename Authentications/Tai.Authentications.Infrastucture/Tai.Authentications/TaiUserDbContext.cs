using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Tai.Authentications.Entities;
using Tai.Authentications.Entities.ValueObjects;

namespace Tai.Authentications.Infrastucture
{
    public class TaiUserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public TaiUserDbContext(DbContextOptions<TaiUserDbContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateUserTable(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static ModelBuilder CreateUserTable(ModelBuilder modelBuilder)
        {
            var jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

            modelBuilder.Entity<User>()
                .ToTable("users")
                .HasKey(t => t.Id);

            modelBuilder.Entity<User>()
                .Property(p => p.UserEmail)
                .HasConversion(p => JsonConvert.SerializeObject(p, Formatting.Indented, jsonSettings),
                               p => JsonConvert.DeserializeObject<UserEmail>(p, jsonSettings));

            modelBuilder.Entity<User>()
                .Property(p => p.UserNameSurname)
                .HasConversion(p => JsonConvert.SerializeObject(p, Formatting.Indented, jsonSettings),
                               p => JsonConvert.DeserializeObject<UserNameSurname>(p, jsonSettings));

            modelBuilder.Entity<User>()
                .Property(p => p.UserLogin)
                .HasConversion(p => JsonConvert.SerializeObject(p, Formatting.Indented, jsonSettings),
                               p => JsonConvert.DeserializeObject<UserLogin>(p, jsonSettings));
            //TODO:Зашифровать пароль.
            modelBuilder.Entity<User>()
                .Property(p => p.UserPassword)
                .HasConversion(p => JsonConvert.SerializeObject(p, Formatting.Indented, jsonSettings),
                               p => JsonConvert.DeserializeObject<UserPassword>(p, jsonSettings));

            //TODO:Добавить игнор сервиса IDateTime в TimeStamp
            modelBuilder.Entity<User>()
                .Property(p => p.TimeStamp)
                .HasConversion(p => JsonConvert.SerializeObject(p, Formatting.Indented, jsonSettings),
                               p => JsonConvert.DeserializeObject<TimeStamp>(p, jsonSettings));

            return modelBuilder;
        }
    }
}
