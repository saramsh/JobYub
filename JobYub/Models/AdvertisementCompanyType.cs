using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobYub.Models
{
	public class AdvertisementCompanyType
	{
		public int ID { get; set; }
		public int CompanyTypetID { get; set; }
		public virtual CompanyType CompanyType { get; set; }
		public int AdvertisementID { get; set; }
		public virtual Advertisement Advertisement { get; set; }
	}
}
