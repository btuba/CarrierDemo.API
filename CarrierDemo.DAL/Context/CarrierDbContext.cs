using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CarrierDemo.DAL.Context
{
    public class CarrierDbContext : DbContext
    {
        DbSet<Carrier>? Carriers { get; set; }
        DbSet<CarrierConfiguration>? CarrierConfigurations { get; set; }
        DbSet<Order>? Orders { get; set; }
        DbSet<CarrierReport>? CarrierReports { get; set; }

        public CarrierDbContext(DbContextOptions<CarrierDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrier>().HasData(
                new Carrier { Id = 1, CarrierName = "KargoFirmaA", CarrierIsActive = true, CarrierPlusDesiCost = 4 },
                new Carrier { Id = 2, CarrierName = "KargoFirmaB", CarrierIsActive = false, CarrierPlusDesiCost = 1 },
                new Carrier { Id = 3, CarrierName = "KargoFirmaC", CarrierIsActive = true, CarrierPlusDesiCost = 2 },
                new Carrier { Id = 4, CarrierName = "KargoFirmaD", CarrierIsActive = true, CarrierPlusDesiCost = 1 },
                new Carrier { Id = 5, CarrierName = "KargoFirmaE", CarrierIsActive = true, CarrierPlusDesiCost = 1 },
                new Carrier { Id = 6, CarrierName = "test1", CarrierIsActive = true, CarrierPlusDesiCost = 4 }
                );

            modelBuilder.Entity<CarrierConfiguration>().HasData(
                new CarrierConfiguration { Id = 1, CarrierId = 1, CarrierCost = 10, CarrierMinDesi = 1, CarrierMaxDesi = 5 },
                new CarrierConfiguration { Id = 2, CarrierId = 1, CarrierCost = 12, CarrierMinDesi = 6, CarrierMaxDesi = 10 },
                new CarrierConfiguration { Id = 3, CarrierId = 2, CarrierCost = 1, CarrierMinDesi = 1, CarrierMaxDesi = 5 },
                new CarrierConfiguration { Id = 4, CarrierId = 2, CarrierCost = 1, CarrierMinDesi = 6, CarrierMaxDesi = 9 },
                new CarrierConfiguration { Id = 5, CarrierId = 3, CarrierCost = 10, CarrierMinDesi = 1, CarrierMaxDesi = 5 },
                new CarrierConfiguration { Id = 6, CarrierId = 3, CarrierCost = 12, CarrierMinDesi = 6, CarrierMaxDesi = 10 },
                new CarrierConfiguration { Id = 7, CarrierId = 4, CarrierCost = 12, CarrierMinDesi = 1, CarrierMaxDesi = 3 },
                new CarrierConfiguration { Id = 8, CarrierId = 4, CarrierCost = 14, CarrierMinDesi = 6, CarrierMaxDesi = 10 },
                new CarrierConfiguration { Id = 9, CarrierId = 5, CarrierCost = 15, CarrierMinDesi = 1, CarrierMaxDesi = 5 }
            );

        }
    }
}
