﻿// <auto-generated />
using System;
using JobYub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobYub.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190331100323_dfdfg")]
    partial class dfdfg
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobYub.Models.Advertisement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Age");

                    b.Property<string>("ApplicationUserID");

                    b.Property<int>("CityID");

                    b.Property<int>("CollaborationType");

                    b.Property<bool>("Confirmed");

                    b.Property<string>("Description");

                    b.Property<string>("EducationLevel");

                    b.Property<string>("EndDate");

                    b.Property<int>("Experience");

                    b.Property<int>("Gender");

                    b.Property<string>("Graduated");

                    b.Property<int>("JobCategoryID");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<int>("MajorID");

                    b.Property<int>("MaxSalary");

                    b.Property<int>("MinSalary");

                    b.Property<int?>("PaymentID");

                    b.Property<int>("RegionID");

                    b.Property<int>("ReportNum");

                    b.Property<string>("ReportsDesc");

                    b.Property<string>("StartDate");

                    b.Property<int?>("TagID");

                    b.Property<string>("TagIDs");

                    b.Property<int>("TarrifID");

                    b.Property<string>("Title");

                    b.Property<int>("advertisementType");

                    b.Property<int>("status");

                    b.HasKey("ID");

                    b.HasIndex("ApplicationUserID");

                    b.HasIndex("CityID");

                    b.HasIndex("JobCategoryID");

                    b.HasIndex("MajorID");

                    b.HasIndex("PaymentID");

                    b.HasIndex("RegionID");

                    b.HasIndex("TagID");

                    b.HasIndex("TarrifID");

                    b.ToTable("Advertisement");
                });

            modelBuilder.Entity("JobYub.Models.AdvertisementMajor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdvertisementID");

                    b.Property<int>("MajorID");

                    b.HasKey("ID");

                    b.HasIndex("AdvertisementID");

                    b.HasIndex("MajorID");

                    b.ToTable("AdvertisementMajor");
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

                    b.Property<int>("Experience");

                    b.Property<string>("FirstName");

                    b.Property<bool>("Graduated");

                    b.Property<string>("HomePhone");

                    b.Property<string>("LastName");

                    b.Property<string>("Latitude");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Longtitude");

                    b.Property<int?>("MajorID");

                    b.Property<string>("MilitaryStatus");

                    b.Property<string>("Mobile");

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

                    b.Property<string>("Token");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("VerificationCode");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.HasIndex("CityID");

                    b.HasIndex("CompanyTypeID");

                    b.HasIndex("MajorID");

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

            modelBuilder.Entity("JobYub.Models.Major", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("ParentID");

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.ToTable("Major");
                });

            modelBuilder.Entity("JobYub.Models.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<string>("Date");

                    b.Property<string>("TrackingNumber");

                    b.HasKey("ID");

                    b.ToTable("Payment");
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

            modelBuilder.Entity("JobYub.Models.Tag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Tag");
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
                    b.HasOne("JobYub.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Advertisements")
                        .HasForeignKey("ApplicationUserID");

                    b.HasOne("JobYub.Models.City", "City")
                        .WithMany("Advertisements")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobYub.Models.JobCategory", "JobCategory")
                        .WithMany("Advertisements")
                        .HasForeignKey("JobCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobYub.Models.Major", "Major")
                        .WithMany("Advertisements")
                        .HasForeignKey("MajorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobYub.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentID");

                    b.HasOne("JobYub.Models.Region", "Region")
                        .WithMany("Advertisements")
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobYub.Models.Tag")
                        .WithMany("Advertisements")
                        .HasForeignKey("TagID");

                    b.HasOne("JobYub.Models.Tarrif", "Tarrif")
                        .WithMany("Advertisements")
                        .HasForeignKey("TarrifID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JobYub.Models.AdvertisementMajor", b =>
                {
                    b.HasOne("JobYub.Models.Advertisement", "Advertisement")
                        .WithMany("AdvertisementMajors")
                        .HasForeignKey("AdvertisementID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JobYub.Models.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorID")
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

                    b.HasOne("JobYub.Models.Major", "Major")
                        .WithMany("Users")
                        .HasForeignKey("MajorID");

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

            modelBuilder.Entity("JobYub.Models.Major", b =>
                {
                    b.HasOne("JobYub.Models.Major", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentID")
                        .OnDelete(DeleteBehavior.Cascade);
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
