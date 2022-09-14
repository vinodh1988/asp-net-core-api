using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.CompilerServices;

namespace CrudAPI.Models
{
    public class SQLiteDBContext : DbContext
    {
        public DbSet<Person> people { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }

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
                .HasColumnType("NUMBER(5)")
                .ValueGeneratedNever();

                entity.Property(e => e.Name)
               .HasColumnName("name")
               .HasMaxLength(30)
               .IsRequired();

                entity.Property(e => e.City)
               .HasColumnName("city")
               .HasMaxLength(30)
               .IsRequired();



            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Dno).HasName("Pk_dno");

                entity.ToTable("department");

                entity.Property(e => e.Dno)
                .HasColumnName("dno")
                .HasColumnType("NUMBER(5)")
                .ValueGeneratedNever();

                entity.Property(e => e.Name)
               .HasColumnName("name")
               .HasMaxLength(30)
               .IsRequired();

      



            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Eno).HasName("Pk_eno");

                entity.ToTable("employee");

                entity.Property(e => e.Eno)
                .HasColumnName("eno")
                .HasColumnType("NUMBER(5)")
                .ValueGeneratedNever();

                entity.Property(e => e.Name)
               .HasColumnName("name")
               .HasMaxLength(30)
               .IsRequired();

                entity.Property(e => e.City)
               .HasColumnName("city")
               .HasMaxLength(30)
               .IsRequired();

               entity.Property(e => e.Dno)
              .HasColumnName("dno")
              .HasColumnType("NUMBER(5)")
              .IsRequired();



            });

            modelBuilder.Entity<Department>().
                HasMany(e=> e.Employees)
                .WithOne(d=>d.Dept)
                .HasForeignKey(d=>d.Dno)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}