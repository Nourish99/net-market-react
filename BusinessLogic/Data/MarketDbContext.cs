using System;
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Data
{
	public class MarketDbContext : DbContext
	{

        public MarketDbContext()
        {

        }
        public MarketDbContext(DbContextOptions<MarketDbContext> options) : base(options)
        {

        }

		public DbSet<Product> Products { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("A FALLBACK CONNECTION STRING");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

