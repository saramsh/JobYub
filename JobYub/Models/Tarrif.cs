using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobYub.Models
{
    public class Tarrif
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Days { get; set; }
		public string Price { get; set; }
		public int PriorityID { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }

    }
}
