using CourseWorkWeb.DAL.Context.Config;
using CourseWorkWeb.Models.Entity;
using CourseWorkWeb.Models.Entity.Auth;
using CourseWorkWeb.Models.Entity.Diseases;
using CourseWorkWeb.Models.Entity.Medicines;
using CourseWorkWeb.Models.Entity.Orders;
using CourseWorkWeb.Models.Entity.Photos;
using CourseWorkWeb.Models.Entity.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWorkWeb.DAL.Context
{
    public class MedicineDataContext : DbContext
    {
        public MedicineDataContext()
        {
            
        }
        public MedicineDataContext(DbContextOptions<MedicineDataContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>()
            .Property(m => m.Cost)
            .HasColumnType("decimal(10, 2)");
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RolesPermissionsConfiguration());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
        
        
        


        //UserElement:
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        //DiseaseElement:
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        //MedicineElement:
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Substance> Substances { get; set; }
        //OrderElement:
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeadLine> DeadLines { get; set; }
        //PhotosElement:
        public DbSet<MedicinePhoto> MedicinePhotos { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; } 
        //Relations:
        public DbSet<UserRole> userRoles { get; set; }
        public DbSet<MedicinesOrders> MedicinesOrders { get; set; }
        public DbSet<MedicinesSubstances> MedicinesSubstances { get; set; }
        public DbSet<PharmaciesMedicines> PharmaciesMedicines { get; set; }
        public DbSet<SubstancesSymptoms> SubstancesSymptoms { get; set; }
        public DbSet<SymptomsDiseases> SymptomsDiseases { get; set; }
        public DbSet<RolesPermissions> RolesPermissions { get; set; }
        //Other Entities:
        public DbSet<Pharmacist> Pharmacists { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
    }
}
