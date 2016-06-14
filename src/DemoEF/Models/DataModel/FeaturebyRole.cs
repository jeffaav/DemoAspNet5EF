using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class FeaturebyRole
    {
        public FeaturebyRole()
        {
            Estimation = new HashSet<Estimation>();
        }

        public int RoleID { get; set; }
        public int FeatureID { get; set; }
        public int? Complexity { get; set; }
        public bool? Blocked { get; set; }
        public DateTime ModificationDate { get; set; }

        public virtual ICollection<Estimation> Estimation { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual Role Role { get; set; }
    }
}
