using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TaiProgramms.Entities;
using TaiProgramms.Entities.ValueObjects;

namespace Tai.Programs.Infrastructure
{
    public class TaiProgrammDbContext : DbContext
    {
        public DbSet<TaiProgramm> TaiProgramms { get; set; }

        public TaiProgrammDbContext(DbContextOptions<TaiProgrammDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateTaiProgrammTable(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static ModelBuilder CreateTaiProgrammTable(ModelBuilder modelBuilder)
        {
            var jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

            modelBuilder.Entity<TaiProgramm>()
                .ToTable("programm")
                .HasKey(t => t.Id);

            modelBuilder.Entity<TaiProgramm>()
                .Property(p => p.Title)
                .HasConversion(p => JsonConvert.SerializeObject(p, Formatting.Indented, jsonSettings),
                               p => JsonConvert.DeserializeObject<Title>(p, jsonSettings));

            modelBuilder.Entity<TaiProgramm>()
                .Property(p => p.ShortDescription)
                .HasConversion(p => JsonConvert.SerializeObject(p, Formatting.Indented, jsonSettings),
                               p => JsonConvert.DeserializeObject<ShortDescription>(p, jsonSettings));

            modelBuilder.Entity<TaiProgramm>()
                .Property(p => p.Description)
                .HasConversion(p => JsonConvert.SerializeObject(p, Formatting.Indented, jsonSettings),
                               p => JsonConvert.DeserializeObject<Description>(p, jsonSettings));

            return modelBuilder;
        }
    }
}