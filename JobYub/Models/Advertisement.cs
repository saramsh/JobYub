using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobYub.Models
{
    public class Advertisement
    {
        public int ID { get; set; }
        [Display(Name ="عنوان")]
        public string Title { get; set; }
		public string Description { get; set; }

		public string StartDate { get; set; }
		public string EndDate { get; set; }

		public string TagIDs { get; set; }

		public string Experience { get; set; }

		public string CollaborationType { get; set; }

		public int MinSalary { get; set; }

		public int MaxSalary { get; set; }
		public string EducationLevel { get; set; }

		public Int16 Age { get; set; }

		public Gender Gender { get; set; }

		public double Longitude { get; set; }

		public double Latitude { get; set; }

		public bool ActivationStatus { get; set; }

		public int JobCategoryID { get; set; }

		public virtual JobCategory JobCategory { get; set; }

		public int CityID { get; set; }

		public virtual City City { get; set; }

		public int RegionID { get; set; }

		public virtual Region Region { get; set; }

		public int TarrifID { get; set; }

		public virtual Tarrif Tarrif { get; set; }

		public bool Confirmed { get; set; }
       
        

    }
    public enum Gender { male,female,unknown}
}
