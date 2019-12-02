using System;
using DataRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataRepository.Infastructure
{
    public partial class AccountDbContext : DbContext
    {
        public AccountDbContext()
        {
        }

        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerLookup> CustomerLookup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Your connection string here");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                

                entity.Property(e => e.CustomerId).ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CustomerLookup>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Table__3214EC07787589B6");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customerId")
                    .ValueGeneratedNever();

                entity.Property(e => e.OAuthId).HasColumnName("oAuthId");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
