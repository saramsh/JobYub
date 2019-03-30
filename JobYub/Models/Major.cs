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
		public int ParentMajorID { get; set; }
		public virtual Major ParentMajor { get; set; }
        public IEnumerable<AdvertisementMajor> advertisementMajors { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
      
	}
}
