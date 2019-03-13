using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobYub.Models
{
    public class JobCategory
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int ParentID { get; set; }
		public virtual JobCategory ParentCategory { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
