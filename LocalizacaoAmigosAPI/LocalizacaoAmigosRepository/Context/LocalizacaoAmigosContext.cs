namespace LocalizacaoAmigos.Data.Context
{
    using LocalizacaoAmigos.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;

    public class LocalizacaoAmigosContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("LocalizacaoAmigosContext"));
            }
            
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<CalculoHistoricoLog> CalculoHistoricoLog { get; set; }
    }

}
