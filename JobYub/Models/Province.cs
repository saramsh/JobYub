﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobYub.Models
{
    public class Province
    {
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
