using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobYub.Models
{
    public class Payment
    {
		public int ID { get; set; }
		public string Date { get; set; }
		public double Amount { get; set; }
		public string TrackingNumber { get; set; }
	}
}
