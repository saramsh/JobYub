using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobYub.Models
{
    public class UserAdvertisement
    {
		public int ID { get; set; }
		public virtual int UserID { get; set; }
		public virtual ApplicationUser User { get; set; }
		public virtual int AdvertisementID { get; set; }
		public virtual Advertisement Advertisement { get; set; }
	}
}
