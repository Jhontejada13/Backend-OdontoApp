using BackendOdontoApp.API.Data.Entities;
using BackendOdontoApp.API.Models.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendOdontoApp.API.Models.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<CancellationReasons> CancellationReasons { get; set; }
        public DbSet<DentalClinic> DentalClinics { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Speciality> Specialities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CancellationReasons>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<DentalClinic>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<DocumentType>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Procedure>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Speciality>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
