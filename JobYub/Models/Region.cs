using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobYub.Models
{
    public class Region
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int CityID { get; set; }
		public virtual City City { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
