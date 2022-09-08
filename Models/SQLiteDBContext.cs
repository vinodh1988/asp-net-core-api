using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.CompilerServices;

namespace CrudAPI.Models
{
    public class SQLiteDBContext : DbContext
    {
        public DbSet<Person> people { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source='data.db'");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Sno).HasName("Pk_sno");

                entity.ToTable("people");

                entity.Property(e => e.Sno)
                .HasColumnName("sno")
                .HasColumnType("NUMBER(5)");

                entity.Property(e => e.Name)
               .HasColumnName("name")
               .HasMaxLength(30)
               .IsRequired();

                entity.Property(e => e.City)
               .HasColumnName("city")
               .HasMaxLength(30)
               .IsRequired();



            });
        }
    }
}