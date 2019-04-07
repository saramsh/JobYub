using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobYub.Models
{

class test    {




}


    public class Advertisement
	{
		public int ID { get; set; }

		[Display(Name = "عنوان")]
		public string Title { get; set; }

		public string Description { get; set; }

		public string StartDate { get; set; }

		public string EndDate { get; set; }

		public string TagIDs { get; set; }

		public int Experience { get; set; }
        public string PhoneNumber { get; set; }
        public string SalaryType { get; set; }

                                           //	public int MajorId { get; set; }

        public CollaborationType CollaborationType { get; set; }

		public int MinSalary { get; set; }

		public int MaxSalary { get; set; }
       
        public virtual IEnumerable<EducationLevel> EducationLevel {set;get;}

		public Int16 Age { get; set; }
        public int? MaxAge { get; set; }
        public int? MinAge { get; set; }

        public Gender Gender { get; set; }

		public double Longitude { get; set; }

		public double Latitude { get; set; }

		public  int JobCategoryID { get; set; }

		public virtual JobCategory JobCategory { get; set; }

		//[ForeignKey("City")]
		public  int CityID { get; set; }

		public virtual City City { get; set; }

		public int RegionID { get; set; }

		public virtual Region Region { get; set; }

		public int TarrifID { get; set; }

		public virtual Tarrif Tarrif { get; set; }

		//public bool Confirmed { get; set; }

		public int? PaymentID { get; set; }

		public virtual Payment Payment { get; set; }

		public Status status { get; set; }

		public string ReportsDesc { get; set; }

		public int ReportNum { get; set; }

		public bool? Graduated { get; set; }
		public string ApplicationUserID { get; set; }
		public virtual ApplicationUser ApplicationUser { get; set; }

		public virtual IEnumerable<AdvertisementMajor> AdvertisementMajors { get; set; }

		public  AdvertisementType advertisementType {get;set;}
        //public int MajorID { get; set; }
        //public Major Major { get; set; }

    }
    public enum CollaborationType {parttime, fulltime,  both }
    public enum Gender { male,female,unknown}

	public enum Status { waiting, confirmed, deactive}
	public enum AdvertisementType { employerAdds, employeeAdds }
    
    public class AdvertisementSearchModel
    {
        public string KeyWord { get; set; }

        public string Title { get; set; }

        public string City { get; set; }
        public int? JobCategoryID { get; set; }
        public AdvertisementType? AdvertisementType { get; set; }
        public int? Experience { get; set; }
        public CollaborationType? CollaborationType { get; set; }
        public int? Salary { get; set; }
       
        public Gender? Gender { get; set; }
        public List<int> CompanyTypeIDs { get; set; }
        public List<int> MajorIDs { get; set; }
        public bool? Graduated { get; set; }
        public  List<EducationLevel> EducationLevel { get; set; }
        

    }

	public class KeywordSearchModel
	{
		public string keyword { get; set; }
		public AdvertisementType AdvertisementType { get; set; }
	}


	public class AdvertisementIDsModel
	{
		public int[] AdvertisementIDs { get; set; }
	}
	public class SearchModel
	{
		public int AdvertisementType { get; set; }
		public int Experience { get; set; }
		public int Salary { get; set; }
		public int CollaborationTypeID { get; set; }
		public int gender { get; set; }
		public string EducationLevel { get; set; }

	}
}
