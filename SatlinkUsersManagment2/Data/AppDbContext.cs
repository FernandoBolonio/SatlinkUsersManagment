﻿using SatlinkUsersManagment2.Models;
using Microsoft.EntityFrameworkCore;

namespace SatlinkUsersManagment2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Address, a =>
                {
                    a.OwnsOne(ad => ad.Geo);
                });

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Company);
        }
    }
}