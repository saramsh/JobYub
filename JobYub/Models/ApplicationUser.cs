using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobYub.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Website { get; set; }
        public string BirthDate { get; set; }
        public string HomePhone { get; set; }
        public string Mobile { get; set; }
        public string EducationLevel { get; set; }
        public int? MajorID { get; set; }
		public virtual Major Major { get; set; }
		public string MilitaryStatus { get; set; }
        public int? CityID { get; set; }
        public virtual City City { get; set; }
        public int? RegionID { get; set; }
        public virtual Region Region { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public byte[] Resume { get; set; }
        public string Company { get; set; }
        public int? CompanyTypeID { get; set; }
        public virtual CompanyType CompanyType { get; set; }
        public string Latitude { get; set; }
        public string Longtitude { get; set; }
        public bool Graduated { get; set; }
        public int Experience { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
		public string VerificationCode { get; set; }


	}

}
