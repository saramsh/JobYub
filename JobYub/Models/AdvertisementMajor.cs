using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobYub.Models
{
    public class AdvertisementMajor
    {
       // public int ID { get; set; }
        public virtual int AdvertisementID { get; set; }
        public virtual Advertisement Advertisement { get; set; }
        public virtual int MajorID { get; set; }
        public virtual Major Major { get; set; }

    }
}
