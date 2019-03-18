﻿// <auto-generated />
using System;
using JobYub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobYub.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190316111730_rtfedg")]
    partial class rtfedg
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobYub.Models.Advertisement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ActivationStatus");

                    b.Property<short>("Age");

                    b.Property<int>("CityID");

                    b.Property<string>("CollaborationType");

                    b.Property<bool>("Confirmed");

                    b.Property<string>("Description");

                    b.Property<string>("EducationLevel");

                    b.Property<string>("EndDate");

                    b.Property<string>("Experience");

                    b.Property<bool>("Gender");

                    b.Property<int>("JobCategoryID");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<int>("MaxSalary");

                    b.Property<int>("MinSalary");

                    b.Property<int>("RegionID");

                    b.Property<string>("StartDate");

                    b.Property<string>("TagIDs");

                    b.Property<int>("TarrifID");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.HasIndex("JobCategoryID");

                    b.HasIndex("RegionID");

                    b.HasIndex("TarrifID");

                    b.ToTable("Advertisement");
                });

            modelBuilder.Entity("JobYub.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("BirthDate");

                    b.Property<int?>("CityID");

                    b.Property<string>("Company");

                    b.Property<int?>("CompanyTypeID");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("EducationLevel");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("Graduated");

                    b.Property<string>("HomePhone");

                    b.Property<string>("LastName");

                    b.Property<string>("Latitude");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Longtitude");

                    b.Property<string>("Major");

                    b.Property<string>("MilitaryStatus");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Photo");

                    b.Property<int?>("RegionID");

                    b.Property<byte[]>("Resume");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.HasIndex("CityID");

                    b.HasIndex("CompanyTypeID");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RegionID");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("JobYub.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("ProvinceID");

                    b.HasKey("ID");

                    b.HasIndex("ProvinceID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("JobYub.Models.CompanyType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("CompanyType");
                });

            modelBuilder.Entity("JobYub.Models.JobCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentCategoryID");

                    b.Property<int>("ParentID");

                    b.HasKey("ID");

                    b.HasIndex("ParentCategoryID");

                    b.ToTable("JobCategory");
                });

            modelBuilder.Entity("JobYub.Models.Province", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("JobYub.Models.Region", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("JobYub.Models.Tarrif", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Days");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Price");

                    b.Property<int>("PriorityID");

                    b.HasKey("ID");

                    b.ToTable("Tarrif");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JobYub.Models.Advertisement", b =>
                {
                    b.HasOne("JobYub.Models.City", "City")
                        .WithMany("Advertisements")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobYub.Models.JobCategory", "JobCategory")
                        .WithMany("Advertisements")
                        .HasForeignKey("JobCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobYub.Models.Region", "Region")
                        .WithMany("Advertisements")
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobYub.Models.Tarrif", "Tarrif")
                        .WithMany("Advertisements")
                        .HasForeignKey("TarrifID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobYub.Models.ApplicationUser", b =>
                {
                    b.HasOne("JobYub.Models.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityID");

                    b.HasOne("JobYub.Models.CompanyType", "CompanyType")
                        .WithMany("Users")
                        .HasForeignKey("CompanyTypeID");

                    b.HasOne("JobYub.Models.Region", "Region")
                        .WithMany("Users")
                        .HasForeignKey("RegionID");
                });

            modelBuilder.Entity("JobYub.Models.City", b =>
                {
                    b.HasOne("JobYub.Models.Province", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobYub.Models.JobCategory", b =>
                {
                    b.HasOne("JobYub.Models.JobCategory", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryID");
                });

            modelBuilder.Entity("JobYub.Models.Region", b =>
                {
                    b.HasOne("JobYub.Models.City", "City")
                        .WithMany("Regions")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JobYub.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JobYub.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobYub.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JobYub.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}