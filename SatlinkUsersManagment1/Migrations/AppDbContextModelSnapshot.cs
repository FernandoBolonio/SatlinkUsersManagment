﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SatlinkUsersManagment1.Data;

#nullable disable

namespace SatlinkUsersManagment1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SatlinkUsersManagment1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SatlinkUsersManagment1.Models.User", b =>
                {
                    b.OwnsOne("SatlinkUsersManagment1.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Suite")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Zipcode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Addresses");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.OwnsOne("SatlinkUsersManagment1.Models.Geo", "Geo", b2 =>
                                {
                                    b2.Property<int>("AddressUserId")
                                        .HasColumnType("int");

                                    b2.Property<double>("Lat")
                                        .HasColumnType("float");

                                    b2.Property<double>("Lng")
                                        .HasColumnType("float");

                                    b2.HasKey("AddressUserId");

                                    b2.ToTable("Geos");

                                    b2.WithOwner()
                                        .HasForeignKey("AddressUserId");
                                });

                            b1.Navigation("Geo")
                                .IsRequired();
                        });

                    b.OwnsOne("SatlinkUsersManagment1.Models.Company", "Company", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Bs")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CatchPhrase")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("Companies");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Company")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
