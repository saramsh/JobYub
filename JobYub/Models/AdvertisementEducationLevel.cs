using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobYub.Models
{
    public class AdvertisementEducationLevel
    {
        public int ID { get; set; }
        public virtual int AdvertisementID { get; set; }
        public virtual Advertisement Advertisement { get; set; }
        public virtual int EducationLevelID { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }

    }
}
