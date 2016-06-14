using System;
using System.Collections.Generic;

namespace DemoEF.Models.DataModel
{
    public partial class Feature
    {
        public Feature()
        {
            DocumentbyFeature = new HashSet<DocumentbyFeature>();
            FeaturebyRole = new HashSet<FeaturebyRole>();
            MissingInformation = new HashSet<MissingInformation>();
        }

        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public int ModuleID { get; set; }
        public decimal? TotalHours { get; set; }
        public int? GenericFeatureID { get; set; }
        public DateTime ModificationDate { get; set; }

        public virtual ICollection<DocumentbyFeature> DocumentbyFeature { get; set; }
        public virtual ICollection<FeaturebyRole> FeaturebyRole { get; set; }
        public virtual ICollection<MissingInformation> MissingInformation { get; set; }
        public virtual GenericFeature GenericFeature { get; set; }
        public virtual Module Module { get; set; }
    }
}
