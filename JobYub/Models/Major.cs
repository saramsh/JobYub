using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobYub.Models
{
	public class Major
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual int ParentID { get; set; }
		public virtual Major Parent { get; set; }
		public virtual ICollection<AdvertisementMajor> AdvertisementMajors { get; set; }
		public virtual ICollection<ApplicationUser> Users { get; set; }
	}
}
