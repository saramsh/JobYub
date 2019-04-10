using System;
using System.Collections.Generic;
using System.Text;
using JobYub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobYub.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AdvertisementMajor>().HasKey(am => new { am.AdvertisementID, am.MajorID });
            builder.Entity<AdvertisementEducationLevel>().HasKey(ae => new { ae.AdvertisementID, ae.EducationLevelID });

       
    }
        public DbSet<JobYub.Models.City> City { get; set; }
        public DbSet<JobYub.Models.Advertisement> Advertisement { get; set; }
        public DbSet<JobYub.Models.CompanyType> CompanyType { get; set; }
        public DbSet<JobYub.Models.JobCategory> JobCategory { get; set; }
        public DbSet<JobYub.Models.Province> Province { get; set; }
        public DbSet<JobYub.Models.Region> Region { get; set; }
        public DbSet<JobYub.Models.Tag> Tag { get; set; }
        public DbSet<JobYub.Models.Tarrif> Tarrif { get; set; }
        public DbSet<JobYub.Models.Payment> Payment { get; set; }
        public DbSet<JobYub.Models.Major> Major { get; set; }
		public DbSet<JobYub.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<EducationLevel> EducationLevel { get; set; }
        public DbSet<AdvertisementEducationLevel> AdvertisementEducationLevels { get; set; }
        public DbSet<AdvertisementMajor> AdvertisementMajors { get; set; }


	}
}
