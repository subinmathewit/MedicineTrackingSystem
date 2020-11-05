using Microsoft.EntityFrameworkCore;
using MTAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTAPI.Data
{
    public class MedicineTrackingContext:DbContext
    {
        public MedicineTrackingContext (DbContextOptions<MedicineTrackingContext> options):base(options)
        {

        }

        public DbSet<Medicine> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(1000);
                entity.Property(p => p.Brand).HasMaxLength(500);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
                entity.Property(p => p.Quantity);
                entity.Property(p => p.ExpiryDate).HasColumnType("date");
                entity.Property(p => p.Notes).HasMaxLength(2000);
            });
        }
    }
}
