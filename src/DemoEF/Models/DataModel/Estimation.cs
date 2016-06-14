using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class Estimation
    {
        public int EstimationID { get; set; }
        public int EstimationUserID { get; set; }
        public int FeatureID { get; set; }
        public int RoleID { get; set; }
        public decimal Hours { get; set; }
        public DateTime EstimationDate { get; set; }
        public int Status { get; set; }
        public DateTime ModificationDate { get; set; }

        public virtual User EstimationUser { get; set; }
        public virtual FeaturebyRole FeaturebyRole { get; set; }
    }
}
