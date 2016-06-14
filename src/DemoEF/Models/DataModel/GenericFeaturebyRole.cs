using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class GenericFeaturebyRole
    {
        public int GenericFeatureID { get; set; }
        public int RoleID { get; set; }
        public decimal? TotalHours { get; set; }
        public int Count { get; set; }

        public virtual GenericFeature GenericFeature { get; set; }
        public virtual Role Role { get; set; }
    }
}
