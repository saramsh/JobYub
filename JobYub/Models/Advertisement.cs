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

		public int Experience { get; set; }

		public CollaborationType CollaborationType { get; set; }

		public int MinSalary { get; set; }

		public int MaxSalary { get; set; }

        public string EducationLevel { get; set; }

		public Int16 Age { get; set; }

		public Gender Gender { get; set; }

		public double Longitude { get; set; }

		public double Latitude { get; set; }

		public int JobCategoryID { get; set; }

		public virtual JobCategory JobCategory { get; set; }

		public int CityID { get; set; }

		public virtual City City { get; set; }

		public int RegionID { get; set; }

		public virtual Region Region { get; set; }

		public int TarrifID { get; set; }

		public virtual Tarrif Tarrif { get; set; }

		public bool Confirmed { get; set; }

		public int? PaymentID { get; set; }

		public virtual Payment Payment { get; set; }

		public Status status { get; set; }

		public string ReportsDesc { get; set; }

		public int ReportNum { get; set; }

		public string Graduated { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

		public virtual IEnumerable<AdvertisementMajor> AdvertisementMajors { get; set; }

		public 
    }
    public enum CollaborationType {parttime, fulltime,  both }
    public enum Gender { male,female,unknown}

	public enum Status { waiting, confirmed, deactive}
	public enum Type { employerAdds, employeeAdds }

	public class AdvertisementSearchModel
    {
        public string Title { get; set; }
        public string City { get; set; }
        public string JobCategory { get; set; }
        public string Role { get; set; }
    }
}
